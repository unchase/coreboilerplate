﻿using CoreBoilerplate.Application.Abstractions.DapperContexts;
using CoreBoilerplate.Application.Abstractions.EFContexts;
using CoreBoilerplate.Infrastructure.Persistence.EFContexts;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CoreBoilerplate.Infrastructure.Persistence.DapperContexts
{
    //Read details about this implmentation in the interface cs file.
    public class DapperDbWriteContext : IDapperDbWriteContext
    {
        private readonly IApplicationDbContext _context;

        public DapperDbWriteContext(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await _context.Connection.ExecuteAsync(sql, param, transaction);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return (await _context.Connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await _context.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await _context.Connection.QuerySingleAsync<T>(sql, param, transaction);
        }
    }
}