using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodMarket.ChatHubs.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GoodMarket.ChatHubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatStatisticsController : ControllerBase
    {
        private readonly IHubContext<MainChatHub, IClientChatHub> _chatHubContext;

        public ChatStatisticsController(IHubContext<MainChatHub, IClientChatHub> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }

        /// <summary>
        /// Получить названия всех групп SignalR
        /// </summary>
        /// <returns></returns>
        [HttpGet("Groups")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> GetGroups()
        {
            return Ok();
        }

        /// <summary>
        /// Информация по группе
        /// </summary>
        /// <returns></returns>
        [HttpGet("Groups/{groupName}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetGroup(string groupName)
        {
            return Ok();
        }

        /// <summary>
        /// Получить всех юзеров группы
        /// </summary>
        /// <returns></returns>
        [HttpGet("Groups/{groupName}/Users")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> GetGroupUsers(string groupName)
        {
            return Ok();
        }

        //[HttpGet("Groups/{groupName:string}/Users}")]
        //public async Task<IActionResult> GetGroups(string groupName)
        //{
        //    return Ok();
        //}
    }
}