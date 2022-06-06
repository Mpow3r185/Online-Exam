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
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<PhoneNumber> genericCRUD;
        #endregion Fields


        #region Constructor
        public PhoneNumberRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<PhoneNumber>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor


        #region CRUD_Operation

        #region GetPhoneNumbers
        // Get Phone Numbers
        public List<PhoneNumber> GetPhoneNumbers()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetPhoneNumbers

        #region CreatePhoneNumber
        // Create Phone Number
        public bool CreatePhoneNumber(PhoneNumber phoneNumber)
        {
            return genericCRUD.Create(phoneNumber);

        }
        #endregion CreatePhoneNumber

        #region UpdatePhoneNumber
        // Update Phone Number
        public bool UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            return genericCRUD.Update(phoneNumber);
        }
        #endregion UpdatePhoneNumber

        #region DeletePhoneNumber
        // Delete Phone Number
        public bool DeletePhoneNumber(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeletePhoneNumber

        #endregion CRUD_Operation
    }
}
