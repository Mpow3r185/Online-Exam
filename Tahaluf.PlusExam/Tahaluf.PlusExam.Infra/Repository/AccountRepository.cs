using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Commom;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class AccountRepository : IAccountRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<Account> genericCRUD;
        #endregion Fields

        #region Constructor
        public AccountRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<Account>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetAccounts
        public List<Account> GetAccounts()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetAccounts

        #region CreateAccount
        public bool CreateAccount(Account account)
        {
            return genericCRUD.Create(account);
        }
        #endregion CreateAccount

        #region UpdateAccount
        public bool UpdateAccount(Account account)
        {
            return genericCRUD.Update(account);
        }
        #endregion UpdateAccount

        #region DeleteAccount
        public bool DeleteAccount(int accid)
        {
            return genericCRUD.Delete(accid);
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

        public Account UserLogin(UserInfoDTO userInfoDTO)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("uName",
                userInfoDTO.Username,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            parameters.Add("passw",
                            userInfoDTO.Password,
                            dbType: DbType.String,
                            direction: ParameterDirection.Input);
            IEnumerable<Account> result = dbContext.Connection.Query<Account>(
                "AccountPackage.Login", parameters,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }
    }
}