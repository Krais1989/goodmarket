using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application.SignInOut
{
    public class GetCurrentUserRequest : IRequest<GetCurrentUserResponse> { }

    public class GetCurrentUserResponse
    {
        public string Email { get; set; }
    }

    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
    {
        private IHttpContextAccessor _httpContextAccessor;
        private GMUserManager _gmUserMan;

        public GetCurrentUserHandler(IHttpContextAccessor httpContextAccessor, GMUserManager gmUserMan)
        {
            _httpContextAccessor = httpContextAccessor;
            _gmUserMan = gmUserMan;
        }

        public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _gmUserMan.GetUserAsync(_httpContextAccessor.HttpContext.User);
            
            return new GetCurrentUserResponse()
            {
                Email = user.Email
            };
        }
    }
}
