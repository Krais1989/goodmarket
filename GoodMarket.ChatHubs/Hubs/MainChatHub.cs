using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodMarket.ChatHubs
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
    /// Интерфейс серверного хаба  SignalR
    /// </summary>
    public class MainChatHub : Hub<IClientChatHub>
    {
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
