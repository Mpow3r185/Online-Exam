using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public CreditCardRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCreditCards
        public List<CreditCard> GetCreditCards()
        {
            return dbContext.Connection.Query<CreditCard>(
                "CreditCardPackage.GetCreditCards", 
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetCreditCards

        #region CreateCreditCard
        public bool CreateCreditCard(CreditCard creditCard)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("card_number",
                creditCard.CardNumber,
                dbType: DbType.Int64,
                direction: ParameterDirection.Input);

            parameters.Add("amount",
                creditCard.Balance,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("acc_id",
                creditCard.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "CreditCardPackage.CreateCreditCard", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateCreditCard

        #region UpdateCreditCard
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("card_id", 
                creditCard.Id,
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("card_number",
                creditCard.CardNumber,
                dbType: DbType.Int64,
                direction: ParameterDirection.Input);

            parameters.Add("amount",
                creditCard.Balance, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("acc_id", 
                creditCard.AccountId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "CreditCardPackage.UpdateCreditCard", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateCreditCard

        #region DeleteCreditCard
        public bool DeleteCreditCard(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("card_id",
                id, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            dbContext.Connection.ExecuteAsync(
                "CreditCardPackage.DeleteCreditCard", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteCreditCard

        #endregion CRUD_Operation
    }
}
