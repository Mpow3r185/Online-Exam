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
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        public PhoneNumberService(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
          
        }

        public bool CreatePhoneNumber(PhoneNumber phoneNumber)
        {
            return _phoneNumberRepository.CreatePhoneNumber(phoneNumber);
        }

        public bool DeletePhoneNumber(int id)
        {
            return _phoneNumberRepository.DeletePhoneNumber(id);
        }

        public List<PhoneNumber> GetAll()
        {
            return _phoneNumberRepository.GetPhoneNumbers();
        }

        public bool UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            return _phoneNumberRepository.UpdatePhoneNumber(phoneNumber);
        }
    }
}
