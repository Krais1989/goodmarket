using GoodMarket.RabbitMQ.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodMarket.RabbitMQ
{
    public interface IRabbitManager
    {
        IConnection Connection { get; }
        IModel Model { get; }
        RabbitOptions RabbitOptions { get; }

        void EnsureAll();
    }

    /// <summary>
    /// Поднимает все необходимые настройки RabbitMQ
    /// </summary>
    public class RabbitManager : IRabbitManager, IDisposable
    {
        public IConnection Connection { get; private set; }
        public IModel Model { get; private set; }
        public RabbitOptions RabbitOptions { get; private set; }

        public RabbitManager(
            IConnection connection,
            IOptions<RabbitOptions> rabbitOptions)
        {
            Connection = connection;
            RabbitOptions = rabbitOptions.Value;
            RabbitOptions.RemoveInvalids();

            Model = Connection.CreateModel();
        }

        public void Dispose()
        {
            if (Model != null && Model.IsOpen)
                Model.Close();
        }

        public void EnsureAll()
        {
            DoInInnerChannel(model =>
            {
                foreach (var q in RabbitOptions.Queues.Values)
                    EnsureQueue(model, q);
                foreach (var e in RabbitOptions.Exchanges.Values)
                    if (e.IsValid) EnsureExchange(model, e);
                foreach (var qb in RabbitOptions.QueueBinds)
                    EnsureQueryBind(model, qb);
                foreach (var eb in RabbitOptions.ExchangeBinds)
                    EnsureExchangeBind(model, eb);
            });
        }

        public QueueDeclareOk EnsureQueue(QueueOptions queue) => DoInInnerChannel(model => EnsureQueue(model, queue));
        public QueueDeclareOk EnsureQueue(IModel model, QueueOptions queue)
            => model.QueueDeclare(queue.Queue, queue.Durable, queue.Exclusive, queue.AutoDelete, queue.Arguments);

        public void EnsureExchange(ExchangeOptions exchange) => DoInInnerChannel(model => EnsureExchange(model, exchange));
        public void EnsureExchange(IModel model, ExchangeOptions exchange)
            => model.ExchangeDeclare(exchange.Exchange, exchange.Type, exchange.Durable, exchange.AutoDelete, exchange.Arguments);

        public void EnsureExchangeBind(ExchangeBindOptions exchangeBind) => DoInInnerChannel(model => EnsureExchangeBind(model, exchangeBind));
        public void EnsureExchangeBind(IModel model, ExchangeBindOptions exchangeBind)
            => model.ExchangeBind(exchangeBind.Destination, exchangeBind.Source, exchangeBind.RoutingKey);

        public void EnsureQueryBind(QueueBindOptions queryBind) => DoInInnerChannel(model => EnsureQueryBind(model, queryBind));
        public void EnsureQueryBind(IModel model, QueueBindOptions queryBind)
            => model.QueueBind(queryBind.Queue, queryBind.Exchange, queryBind.RoutingKey);

        protected TResult DoInInnerChannel<TResult>(Func<IModel, TResult> action) => action(Model);
        protected void DoInInnerChannel(Action<IModel> action) => action(Model);

        protected TResult DoInNewChannel<TResult>(Func<IModel, TResult> action)
        {
            using (var model = Connection.CreateModel())
                return action(model);
        }
        protected void DoInNewChannel(Action<IModel> action)
        {
            using (var model = Connection.CreateModel())
                action(model);
        }
    }
}
