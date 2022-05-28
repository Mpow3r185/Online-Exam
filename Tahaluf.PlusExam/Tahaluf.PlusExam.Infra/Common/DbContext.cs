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
                if (_dbConnection == null)
                {
                    //connect
                    _dbConnection = new OracleConnection(_Configuration["ConnectionStrings:DBConnectionString"]);
                    _dbConnection.Open();
                }
                else if (_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }

                return _dbConnection;
            }

        }
    }
}
