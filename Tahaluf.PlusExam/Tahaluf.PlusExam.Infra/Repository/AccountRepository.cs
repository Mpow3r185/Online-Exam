using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class AccountRepository : IAccountRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public AccountRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetAccounts
        public List<Account> GetAccounts()
        {
            return dbContext.Connection.Query<Account>(
                "AccountPackage.GetAccounts",
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetAccounts

        #region CreateAccount
        public bool CreateAccount(Account account)
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

            dbContext.Connection.ExecuteAsync(
                "AccountPackage.CreateAccount", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateAccount

        #region UpdateAccount
        public bool UpdateAccount(Account account)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("accid",
                account.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

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

            dbContext.Connection.ExecuteAsync(
                "AccountPackage.UpdateAccount", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateAccount

        #region DeleteAccount
        public bool DeleteAccount(int accid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("accid",
                accid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync(
                "AccountPackage.DeleteAccount", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteAccount

        #endregion CRUD_Operation

        public bool BlockUser(UniqueAccountData uniqueAccountData)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("accid",
                uniqueAccountData.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("uName",
                uniqueAccountData.Username,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("mail",
                uniqueAccountData.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync(
                "AccountPackage.BlockUser", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Account> GetBlockAccounts()
        {
            return dbContext.Connection.Query<Account>(
                "AccountPackage.GetBlockAccounts",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public List<string> GetBlockedUsernames()
        {
            return dbContext.Connection.Query<string>(
                "AccountPackage.GetBlockedUsernames",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public List<string> GetEmails()
        {
            return dbContext.Connection.Query<string>(
                "AccountPackage.GetEmails",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public List<string> GetFullNames()
        {
            return dbContext.Connection.Query<string>(
                "AccountPackage.GetFullNames",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public List<string> GetUsernames()
        {
            return dbContext.Connection.Query<string>(
                "AccountPackage.GetUsernames",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public List<Account> SearchAccount(AccountFilter accountFilter)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("uName",
                accountFilter.Username,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("mail",
                accountFilter.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("fName",
                accountFilter.Fullname,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("rName",
                accountFilter.Rolename,
                dbType: DbType.String,
                direction: ParameterDirection.Input);


            return dbContext.Connection.Query<Account>(
                "AccountPackage.SearchAccount", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }

        public bool UnblockUser(UniqueAccountData uniqueAccountData)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("accid",
                uniqueAccountData.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("uName",
                uniqueAccountData.Username,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("mail",
                uniqueAccountData.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync(
                "AccountPackage.UnblockUser", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        
    }
}
