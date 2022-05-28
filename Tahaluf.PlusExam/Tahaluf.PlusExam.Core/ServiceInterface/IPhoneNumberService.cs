using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IPhoneNumberService
    {
        //Get All Phone Numbers
        List<PhoneNumber> GetAll();
        //Create
        bool CreatePhoneNumber(PhoneNumber phoneNumber);
        //Update
        bool UpdatePhoneNumber(PhoneNumber phoneNumber);
        //Delete
        bool DeletePhoneNumber(int id);
    }
}
