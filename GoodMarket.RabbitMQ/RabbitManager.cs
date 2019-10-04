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
        IList<RabbitSchema> RabbitSchemas { get; }

        void EnsureAll();
    }

    /// <summary>
    /// Поднимает все необходимые настройки RabbitMQ
    /// </summary>
    public class RabbitManager : IRabbitManager, IDisposable
    {
        public IConnection Connection { get; private set; }
        public IModel Model { get; private set; }
        public IList<RabbitSchema> RabbitSchemas { get; private set; }

        public RabbitManager(
            IConnection connection,
            IEnumerable<IOptions<RabbitSchema>> rabbitSchema)
        {
            Connection = connection;
            RabbitSchemas = rabbitSchema.Select(e => e.Value).ToList();
            foreach (var schema in RabbitSchemas)
                schema.RemoveInvalids();
            Model = Connection.CreateModel();
        }

        public void Dispose()
        {
            if (Model != null && Model.IsOpen)
                Model.Close();
        }

        /// <summary>
        /// Реализация схемы RabbitMQ
        /// </summary>
        public void EnsureAll()
        {
            foreach (var rabbitSchema in RabbitSchemas)
            {
                DoInInnerChannel(model =>
                {
                    foreach (var q in rabbitSchema.Queues.Values)
                        EnsureQueue(model, q);
                    foreach (var e in rabbitSchema.Exchanges.Values)
                        if (e.IsValid) EnsureExchange(model, e);
                    foreach (var qb in rabbitSchema.QueueBinds)
                        EnsureQueryBind(model, qb);
                    foreach (var eb in rabbitSchema.ExchangeBinds)
                        EnsureExchangeBind(model, eb);
                });
            }
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

        /// <summary>
        /// Выполнение функции в рамках базового канала Rabbit
        /// </summary>
        protected TResult DoInInnerChannel<TResult>(Func<IModel, TResult> action) => action(Model);
        /// <summary>
        /// Выполнение Процедуры в рамках базового канала Rabbit
        /// </summary>
        protected void DoInInnerChannel(Action<IModel> action) => action(Model);

        /// <summary>
        /// Выполнение функции в новом канале Rabbit
        /// </summary>
        protected TResult DoInNewChannel<TResult>(Func<IModel, TResult> action)
        {
            using (var model = Connection.CreateModel())
                return action(model);
        }
        /// <summary>
        /// Выполнение процедуры в новом канале Rabbit
        /// </summary>
        /// <param name="action"></param>
        protected void DoInNewChannel(Action<IModel> action)
        {
            using (var model = Connection.CreateModel())
                action(model);
        }
    }
}
