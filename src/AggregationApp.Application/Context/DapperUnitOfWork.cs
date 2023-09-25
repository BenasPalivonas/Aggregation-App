﻿// DapperUnitOfWork.cs

using System.Data;
using MySql.Data.MySqlClient;
using AggregationApp.Domain.Abstractions;

namespace AggregationApp.Application.Context;

public class DapperUnitOfWork : IUnitOfWork
{
    private readonly IDbConnection _connection;
    private IDbTransaction _transaction;

    public DapperUnitOfWork(string connectionString)
    {
        _connection = new MySqlConnection(connectionString);
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public int Commit()
    {
        try
        {
            _transaction.Commit();
            return 1;
        }
        catch
        {
            _transaction.Rollback();
            return 0;
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = _connection.BeginTransaction();
        }
    }

    public void Dispose()
    {
        _transaction?.Commit();
        _connection?.Close();
    }
}