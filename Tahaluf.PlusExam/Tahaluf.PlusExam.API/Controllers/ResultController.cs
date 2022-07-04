using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.ServiceInterface;
using Tahaluf.PlusExam.Infra.Service;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        #region Fields
        private readonly IResultService _resultService;
        private readonly IFillResultService _fillResultService;
        private readonly IScoreService _coreService;
        #endregion Field

        #region Constructor
        public ResultController(IResultService resultService, IFillResultService fillResultService, IScoreService scoreService)
        {
            _resultService = resultService;
            _fillResultService = fillResultService;
            _coreService = scoreService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetResults
        // Get Results
        [HttpGet]
        [ProducesResponseType(typeof(List<Result>), StatusCodes.Status200OK)]
        public List<Result> GetResults()
        {
            return _resultService.GetResults();
        }
        #endregion GetResults

        #region CreateResult
        // Create Result
        [HttpPost]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateResult([FromBody] Result result)
        {
            return _resultService.CreateResult(result);
        }
        #endregion CreateResult

        #region UpdateResult
        // Update Result
        [HttpPut]
        [ProducesResponseType(typeof(List<Result>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateResult([FromBody] Result result)
        {
            return _resultService.UpdateResult(result);
        }
        #endregion UpdateResult

        #region DeleteResult
        // Delete Result
        [HttpDelete]
        [Route("DeleteResult/{id}")]
        public bool DeleteResult(int id)
        {
            return _resultService.DeleteResult(id);
        }
        #endregion DeleteResult

        #endregion CRUD_Operation

        [HttpPost]
        [Route("submit")]
        public void Submit(ExamSubmitDTO examSubmit)
        {
            int accountId = examSubmit.AccountId;
            int examId = examSubmit.ExamId;

            foreach (UserResultsDTO userResult in examSubmit.Results)
            {
                // Single & Multiple Question
                if (userResult.fillResult is null)
                {
                    Result result = new Result();
                    result.AccountId = accountId;
                    result.QuestionOptionId = userResult.optionId;

                    _resultService.CreateResult(result);
                }

                // Fill Question
                else
                {
                    FillResult fillResult = new FillResult();
                    fillResult.QuestionId = userResult.questionId;
                    fillResult.AccountId = accountId;
                    fillResult.Answer = userResult.fillResult;

                    _fillResultService.CreateFillResult(fillResult);
                }
            }

            _coreService.CalculateScore(accountId, examId);
        }
    }
}
