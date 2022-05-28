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
        private readonly IDbContext dbContext;

        public CreditCardRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<CreditCard> GetCreditCards()
        {
            IEnumerable<CreditCard> result = dbContext.Connection.Query<CreditCard>("CreditCardPackage.GetCreditCards", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateCreditCard(CreditCard creditCard)
        {
            var parameters = new DynamicParameters();
            parameters.Add("card_number", creditCard.CardNumber, dbType: DbType.Int64, direction: ParameterDirection.Input);
            parameters.Add("amount", creditCard.Balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("acc_id", creditCard.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CreditCardPackage.CreateCreditCard", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            var parameters = new DynamicParameters();
            parameters.Add("card_id", creditCard.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("card_number", creditCard.CardNumber, dbType: DbType.Int64, direction: ParameterDirection.Input);
            parameters.Add("amount", creditCard.Balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("acc_id", creditCard.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CreditCardPackage.UpdateCreditCard", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCreditCard(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("card_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CreditCardPackage.DeleteCreditCard", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        
       
    }
}
