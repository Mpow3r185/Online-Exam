using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class FillResultService : IFillResultService
    {
        #region Fields
        private readonly IFillResultRepository fillResultRepository;
        #endregion Fields

        #region Constructor
        public FillResultService(IFillResultRepository _fillResultRepository)
        {
            fillResultRepository = _fillResultRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetFillResults
        public List<FillResult> GetFillResults()
        {
            return fillResultRepository.GetFillResults();
        }
        #endregion GetFillResults

        #region CreateFillResult
        public bool CreateFillResult(FillResult fillResult)
        {
            return fillResultRepository.CreateFillResult(fillResult); 
        }
        #endregion CreateFillResult

        #region UpdateFillResult
        public bool UpdateFillResult(FillResult fillResult)
        {
            return fillResultRepository.UpdateFillResult(fillResult); 
        }
        #endregion UpdateFillResult

        #region DeleteFillResult
        public bool DeleteFillResult(int frid)
        {
            return fillResultRepository.DeleteFillResult(frid);
        }
        #endregion DeleteFillResult

        #endregion CRUD_Operation

        public string GetAnswerByQuestionIdAndAccountId(FillResult fillResult)
        {
            return fillResultRepository.GetAnswerByQuestionIdAndAccountId(fillResult);
        }

        public List<FillResult> GetFillResultByQuestionId(int qid)
        {
            return fillResultRepository.GetFillResultByQuestionId(qid);
        }
    }
}
