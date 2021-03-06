﻿using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application.CQRS
{
    public class BaseGetAllQuery<T> : IRequest<IEnumerable<T>>
    where T : IEntity
    {
        public bool Track { get; set; } = false;
        public Func<IEnumerable<T>, IEnumerable<T>> Handle { get; set; } = (e) => e;
        public BaseGetAllQuery() { }
        public BaseGetAllQuery(bool track = false, Func<IEnumerable<T>, IEnumerable<T>> handle = null)
        {
            Track = track;
            if (handle != null)
                Handle = handle;
        }
    }

    public class BaseGetAllQueryHandler<TEntity> : IRequestHandler<BaseGetAllQuery<TEntity>, IEnumerable<TEntity>>
        where TEntity : class, IEntity
        //where TQuery : BaseGetAllQuery<TEntity>
    {
        private DbSet<TEntity> _set;
        public BaseGetAllQueryHandler(GoodMarketDb db)
        {
            _set = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Handle(BaseGetAllQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var quer = request.Track ? _set : _set.AsNoTracking();
            var result = request.Handle(quer);
            return await Task.FromResult(result);
        }
    }
}
