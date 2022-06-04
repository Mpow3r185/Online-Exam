using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillResultController : ControllerBase
    {
        #region Fields
        private readonly IFillResultService fillResultService;
        #endregion Fields

        #region Constructor
        public FillResultController(IFillResultService _fillResultService)
        {
            fillResultService = _fillResultService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetFillResults
        [HttpGet]
        public List<FillResult> GetFillResults()
        {
            return fillResultService.GetFillResults();
        }
        #endregion GetFillResults

        #region CreateFillResult
        [HttpPost]
        public bool CreateFillResult(FillResult fillResult)
        {
            return fillResultService.CreateFillResult(fillResult);
        }
        #endregion CreateFillResult

        #region UpdateFillResult
        [HttpPut]
        public bool UpdateFillResult(FillResult fillResult)
        {
            return fillResultService.UpdateFillResult(fillResult);
        }
        #endregion UpdateFillResult

        #region DeleteFillResult
        [HttpDelete]
        public bool DeleteFillResult(int frid)
        {
            return fillResultService.DeleteFillResult(frid);
        }
        #endregion DeleteFillResult

        #endregion CRUD_Operation

        #region GetAnswerByQuestionIdAndAccountId
        [HttpGet]
        [Route("AnswerByQIdAndAccId")]
        public string GetAnswerByQuestionIdAndAccountId(FillResult fillResult)
        {
            return fillResultService.GetAnswerByQuestionIdAndAccountId(fillResult);
        }
        #endregion GetAnswerByQuestionIdAndAccountId

        #region GetFillResultByQuestionId
        public List<FillResult> GetFillResultByQuestionId(int qid)
        {
            return fillResultService.GetFillResultByQuestionId(qid);
        }
        #endregion GetFillResultByQuestionId
    }
}
