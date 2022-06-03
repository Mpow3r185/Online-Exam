using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IFillResultRepository
    {
        // Get Fill Results
        List<FillResult> GetFillResults();

        // Create Fill Results
        bool CreateFillResult(FillResult fillResult);

        // Update Fill Results
        bool UpdateFillResult(FillResult fillResult);

        // Delete Fill Results
        bool DeleteFillResult(int frid);

        // Get Answer By Question Id And Account Id
        string GetAnswerByQuestionIdAndAccountId(FillResult fillResult);

        // Get Fill Results By Question Id
        List<FillResult> GetFillResultByQuestionId(int qid);
    }
}
