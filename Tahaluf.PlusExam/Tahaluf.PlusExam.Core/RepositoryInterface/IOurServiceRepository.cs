using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IOurServiceRepository
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
