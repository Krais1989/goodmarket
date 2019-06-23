using GoodMarket.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodMarket.IdentityApi.Controllers
{
    /// <summary>
    /// Контроллер входа через внешние сервисы
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalSignInController : ControllerBase
    {
        private readonly GMUserManager _userMan;

        public ExternalSignInController(GMUserManager userMan)
        {
            _userMan = userMan;
        }

        [HttpGet("Vk")]
        public async Task VkSignIn()
        {
            throw new NotImplementedException();
        }
    }
}
