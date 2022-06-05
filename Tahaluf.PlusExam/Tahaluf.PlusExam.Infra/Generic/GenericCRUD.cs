using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Infra.Commom;

namespace Tahaluf.PlusExam.Infra.Generic
{
    public class GenericCRUD<T> : IGenericCRUD<T> where T : class
    {
        private readonly IDbContext dbContext;
        private readonly string type;
        
        public GenericCRUD(IDbContext _dbContext)
        {
            dbContext = _dbContext;
            type = typeof(T).Name;
        }

        public bool Create(T entity)
        {
            switch (type)
            {
                case "Account":
                    DynamicParameters dynamicParameters = GenerateAccountParameters(entity);
                    dynamicParameters.Add("func",
                        "CREATE",
                        dbType: DbType.String);

                    dbContext.Connection.ExecuteAsync(
                        "AccountPackage.AccountCRUD", dynamicParameters,
                        commandType: CommandType.StoredProcedure);

                    return true;
            }
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        private DynamicParameters GenerateAccountParameters(dynamic account)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("uName",
                account.Username,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("passw",
                account.Password,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("mail",
                account.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("fName",
                account.Fullname,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("sex",
                account.Gender,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("birthOfDate",
                account.Bod,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("addr",
                account.Address,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                account.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("rName",
                account.Rolename,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("profileImg",
                account.ProfilePicture,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }
    }
}
