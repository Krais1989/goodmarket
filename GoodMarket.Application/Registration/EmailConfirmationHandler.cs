using GoodMarket.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application.Registration
{
    /// <summary>
    /// Запрос на подтверждение почты
    /// </summary>
    public class EmailConfirmationRequest : IRequest
    {
        public string Email { get; set; }
        public string ConfirmationToken { get; set; }
    }

    public class EmailConfirmationHandler : AsyncRequestHandler<EmailConfirmationRequest>
    {
        private readonly GMUserManager _userMan;

        public EmailConfirmationHandler(GMUserManager userMan)
        {
            _userMan = userMan;
        }

        protected override async Task Handle(EmailConfirmationRequest request, CancellationToken cancellationToken)
        {
            var user = await _userMan.FindByEmailAsync(request.Email);
            var confirmResult = await _userMan.ConfirmEmailAsync(user, request.ConfirmationToken);
            if (!confirmResult.Succeeded)
                throw new EmailConfirmationException(request.Email);
        }
    }
}
