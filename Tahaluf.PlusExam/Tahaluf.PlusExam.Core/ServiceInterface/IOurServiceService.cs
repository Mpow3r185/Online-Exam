using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IOurServiceService
    {
        // Get Service
        List<OurService> GetOurService();

        // Create Service
        bool CreateOurService(OurService ourService);

        // Update Service
        bool UpdateOurService(OurService ourService);

        // Delete Service
        bool DeleteOurService(int id);
    }
}
