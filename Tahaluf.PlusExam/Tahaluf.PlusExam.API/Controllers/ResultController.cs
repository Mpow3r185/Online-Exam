using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        //Get All Result
        [HttpGet]
        [ProducesResponseType(typeof(List<Result>), StatusCodes.Status200OK)]
        public List<Result> GetAllResult()
        {
            return _resultService.GetAllResult();
        }

        //Create
        [HttpPost]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateResult([FromBody] Result result)
        {
            return _resultService.CreateResult(result);
        }

        //Update
        [HttpPut]
        [ProducesResponseType(typeof(List<Result>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateResult([FromBody] Result result)
        {
            return _resultService.UpdateResult(result);
        }

        //Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteResult(int id)
        {
            return _resultService.DeleteResult(id);
        }
    }
}
