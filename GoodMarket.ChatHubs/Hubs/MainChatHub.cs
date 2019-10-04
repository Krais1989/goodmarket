using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GoodMarket.ChatHubs.Hubs
{
    /// <summary>
    /// Интерфейс клиента SignalR
    /// </summary>
    public interface IClientChatHub
    {
        Task SendMessageFromUser(string user, string message);
        Task SendMessageToCaller(string message);
        Task SendMessageToOthers(string message);
        Task SendNotify(string message);
    }

    /// <summary>
    /// Главный хаб чата
    /// </summary>
    public class MainChatHub : Hub<IClientChatHub>
    {
        
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            var user = Context.User;
            var connId = Context.ConnectionId;
            var abortToken = Context.ConnectionAborted;

            var stored = Context.Items;

            await Groups.AddToGroupAsync(connId, "", abortToken);
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            var user = Context.User;
            var connId = Context.ConnectionId;
            var abortToken = Context.ConnectionAborted;

            if (exception != null)  // ошибка сети и тп
            {

            }
            else // connection.stop() на клиенте
            {

            }

            await Groups.AddToGroupAsync(connId, "", abortToken);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageFromUser(string user, string message)
        {
            await Clients.All.SendMessageFromUser(user, message);
        }

        public async Task SendMessageToCaller(string message)
        {
            await Clients.Caller.SendMessageToCaller(message);
        }

        public async Task SendNotify(string message)
        {
            await Clients.All.SendNotify(message);
        }
    }
}
