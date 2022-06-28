using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Tahaluf.PlusExam.Core.Common;

namespace Tahaluf.PlusExam.Infra.Commom
{
    public class DbContext : IDbContext
    {
        private DbConnection _dbConnection;
        private readonly IConfiguration _Configuration;

        public DbContext(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public DbConnection Connection
        {
            get
            {
                try
                {
                    if (_dbConnection == null)
                    {
                        _dbConnection = new OracleConnection(_Configuration["ConnectionStrings:DBConnectionString"]);
                        _dbConnection.Open();
                    }
                    else if (_dbConnection.State != ConnectionState.Open)
                    {
                        _dbConnection.Open();
                    }

                    return _dbConnection;
                }
                catch (OracleException ex) // catches only Oracle errors
                {
                    switch (ex.Number)
                    {
                        case 1:
                            throw new Exception("Error attempting to insert duplicate data.");
                        case 12545:
                            throw new Exception("The database is unavailable.");
                        default:
                            throw new Exception("Database error: " + ex.Message.ToString());
                    }
                }
                catch (Exception ex) // catches any error
                {
                    throw new Exception(ex.Message.ToString());
                }
            }

        }
    }
}
