using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application.SignInOut
{
    public class SignOutRequest : IRequest
    {
    }

    //public class SignOutResponse
    //{
    //}

    public class SignOutHandler : AsyncRequestHandler<SignOutRequest>
    {
        protected override async Task Handle(SignOutRequest request, CancellationToken cancellationToken)
        {
        }
    }
}
