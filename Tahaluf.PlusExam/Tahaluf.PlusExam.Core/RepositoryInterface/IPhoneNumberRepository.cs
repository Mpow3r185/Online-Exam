using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IPhoneNumberRepository
    {
        //Get Phone Numbers
        List<PhoneNumber> GetPhoneNumbers();

        // Create Phone Number
        bool CreatePhoneNumber(PhoneNumber phoneNumber);

        // Update Phone Number
        bool UpdatePhoneNumber(PhoneNumber phoneNumber);

        // Delete Phone Number
        bool DeletePhoneNumber(int id);
    }
}
