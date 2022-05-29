using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class PhoneNumberService : IPhoneNumberService
    {
        #region Fields
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        #endregion Fields

        #region Constructor
        public PhoneNumberService(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreatePhoneNumber
        public bool CreatePhoneNumber(PhoneNumber phoneNumber)
        {
            return _phoneNumberRepository.CreatePhoneNumber(phoneNumber);
        }
        #endregion CreatePhoneNumber

        #region DeletePhoneNumber
        public bool DeletePhoneNumber(int id)
        {
            return _phoneNumberRepository.DeletePhoneNumber(id);
        }
        #endregion DeletePhoneNumber

        #region GetPhoneNumbers
        public List<PhoneNumber> GetPhoneNumbers()
        {
            return _phoneNumberRepository.GetPhoneNumbers();
        }
        #endregion GetPhoneNumbers

        #region UpdatePhoneNumber
        public bool UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            return _phoneNumberRepository.UpdatePhoneNumber(phoneNumber);
        }
        #endregion UpdatePhoneNumber

        #endregion CRUD_Operation
    }
}
