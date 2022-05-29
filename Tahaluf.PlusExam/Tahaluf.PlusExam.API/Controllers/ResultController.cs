using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        #region Fields
        private readonly IResultService _resultService;
        #endregion Field

        #region Constructor
        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
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
    }
}
