using GoodMarket.Domain;
using GoodMarket.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MediatR;
using System.Threading;

namespace GoodMarket.Application.Tests.Registration
{
    public class RegistrationTest:IDisposable
    {
        private readonly ServiceProvider _services;
        private readonly IMediator _mediator;
        private readonly TestGoodMarketDb _db;
        private readonly AccountManager _accMan;

        public RegistrationTest()
        {
            _services = TestDependencyMock.Create().BuildServiceProvider();
            _mediator = _services.GetService<IMediator>();
            _db = _services.GetService<TestGoodMarketDb>();
            _accMan = _services.GetService<AccountManager>();
        }

        public void Dispose()
        {
            _accMan.Dispose();
            _db.Dispose();
        }

        [Fact]
        public async void RegistrationRequest()
        {
            var request = new RegistrationRequest()
            {
                Email = "test@test.ru",
                Password = "123",
                Profile = new Profile
                {
                    FIO = "FIRST MID SECOND",
                    BirthDate = DateTime.Now
                }
            };
            var ct = new CancellationToken();
            var handler = new RegistrationHandler(_db, _accMan);
            var resp = await handler.Handle(request, ct);
            var femail = await _accMan.FindByEmailAsync("test@test.ru");
            var fid = await _accMan.FindByIdAsync(resp.Id);
            Assert.True(true);
        }
    }
}
