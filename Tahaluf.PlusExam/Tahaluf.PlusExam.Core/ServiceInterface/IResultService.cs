using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IResultService
    {
        // Get Results
        List<Result> GetResults();

        // Create Result
        bool CreateResult(Result result);

        // Update Result
        bool UpdateResult(Result result);

        // Delete Result
        bool DeleteResult(int id);
    }
}
