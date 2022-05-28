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
        private readonly IDbContext _dbContext;
        public PhoneNumberRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        // Get All Phone Numbers
        public List<PhoneNumber> GetAll()
        {
            IEnumerable<PhoneNumber> result = _dbContext.Connection.Query<PhoneNumber>("PhoneNumberPackage.GetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // Create
        public bool CreatePhoneNumber(PhoneNumber phoneNumber)
        {
            var p = new DynamicParameters();
            p.Add("PHNUM", phoneNumber.PhoneNum, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ACCID", phoneNumber.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("PhoneNumberPackage.CreatePhoneNumber", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //Update 
        public bool UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            var p = new DynamicParameters();
            p.Add("PHNUMID", phoneNumber.Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PHNUM", phoneNumber.PhoneNum, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ACCID", phoneNumber.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("PhoneNumberPackage.UpdatePhoneNumber", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //Delete
        public bool DeletePhoneNumber(int id)
        {
            var p = new DynamicParameters();
            p.Add("PHNUMID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("PhoneNumberPackage.DeletePhoneNumber", p, commandType: CommandType.StoredProcedure);
            return true;
        }

       
    }
}
