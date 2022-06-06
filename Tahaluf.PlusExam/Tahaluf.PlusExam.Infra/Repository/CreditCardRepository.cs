using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<CreditCard> genericCRUD;
        #endregion Fields

        #region Constructor
        public CreditCardRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<CreditCard>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCreditCards
        public List<CreditCard> GetCreditCards()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetCreditCards

        #region CreateCreditCard
        public bool CreateCreditCard(CreditCard creditCard)
        {

            return genericCRUD.Create(creditCard);
        }
        #endregion CreateCreditCard

        #region UpdateCreditCard
        public bool UpdateCreditCard(CreditCard creditCard)
        {
            return genericCRUD.Update(creditCard);
        }
        #endregion UpdateCreditCard

        #region DeleteCreditCard
        public bool DeleteCreditCard(int id)
        {
            return genericCRUD.Delete(id);
        }

        #endregion DeleteCreditCard


        #endregion CRUD_Operation
        public bool UpdateBalance(int id, double newBalance)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("accid",
                id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("newBalance",
                id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            dbContext.Connection.ExecuteAsync(
                "CreditCardPackage.UpdateBalance", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
