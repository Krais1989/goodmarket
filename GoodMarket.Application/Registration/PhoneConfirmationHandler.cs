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
    public class PhoneConfirmationRequest : IRequest
    {
        public string Phone { get; set; }
        public string ConfirmationToken { get; set; }
    }

    public class PhoneConfirmationHandler : AsyncRequestHandler<PhoneConfirmationRequest>
    {
        private readonly GMUserManager _userMan;

        public PhoneConfirmationHandler(GMUserManager userMan)
        {
            _userMan = userMan;
        }

        protected override async Task Handle(PhoneConfirmationRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
