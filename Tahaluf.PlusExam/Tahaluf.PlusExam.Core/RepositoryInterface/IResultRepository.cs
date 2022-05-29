using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IResultRepository
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
