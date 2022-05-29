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
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        #region Fields
        private readonly IDbContext _dbContext;
        #endregion Fields

        #region Constructor
        public PhoneNumberRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetPhoneNumbers
        // Get Phone Numbers
        public List<PhoneNumber> GetPhoneNumbers()
        {
            return _dbContext.Connection.Query<PhoneNumber>(
                "PhoneNumberPackage.GetAll", 
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetPhoneNumbers

        #region CreatePhoneNumber
        // Create Phone Number
        public bool CreatePhoneNumber(PhoneNumber phoneNumber)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PHNUM", 
                phoneNumber.PhoneNum, 
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("ACCID",
                phoneNumber.AccountId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "PhoneNumberPackage.CreatePhoneNumber", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreatePhoneNumber

        #region UpdatePhoneNumber
        // Update Phone Number
        public bool UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PHNUMID", 
                phoneNumber.Id,
                DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("PHNUM",
                phoneNumber.PhoneNum, 
                dbType: DbType.String, 
                direction: ParameterDirection.Input);

            parameters.Add("ACCID", 
                phoneNumber.AccountId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "PhoneNumberPackage.UpdatePhoneNumber", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdatePhoneNumber

        #region DeletePhoneNumber
        // Delete Phone Number
        public bool DeletePhoneNumber(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PHNUMID", 
                id, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync(
                "PhoneNumberPackage.DeletePhoneNumber", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeletePhoneNumber

        #endregion CRUD_Operation
    }
}
