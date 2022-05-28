using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionOptionController : ControllerBase
    {

        private readonly IQuestionOptionService _questionOptionService;

        public QuestionOptionController(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }


        //Get All QuestionOption
        [HttpGet]
        [ProducesResponseType(typeof(List<QuestionOption>), StatusCodes.Status200OK)]
        public List<QuestionOption> GetAllQuestionOption()
        {
            return _questionOptionService.GetAllQuestionOption();
        }

        //Create
        [HttpPost]
        [ProducesResponseType(typeof(QuestionOption), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateQuestionOption([FromBody] QuestionOption questionOption)
        {
            return _questionOptionService.CreateQuestionOption(questionOption);
        }

        //Update
        [HttpPut]
        [ProducesResponseType(typeof(List<QuestionOption>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateQuestionOption([FromBody] QuestionOption questionOption)
        {
            return _questionOptionService.UpdateQuestionOption(questionOption);
        }

        //Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteQuestionOption(int id)
        {
            return _questionOptionService.DeleteQuestionOption(id);
        }
    }
}
