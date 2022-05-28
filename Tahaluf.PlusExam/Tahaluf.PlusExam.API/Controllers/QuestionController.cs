using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        //Get All Question
        [HttpGet]
        [ProducesResponseType(typeof(List<Question>), StatusCodes.Status200OK)]
        public List<Question> GetAllQuestion()
        {
            return _questionService.GetAllQuestion();
        }

        //Create
        [HttpPost]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateQuestion([FromBody] Question question)
        {
            return _questionService.CreateQuestion(question);
        }

        //Update
        [HttpPut]
        [ProducesResponseType(typeof(List<Question>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateQuestion([FromBody] Question question)
        {
            return _questionService.UpdateQuestion(question);
        }

        //Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteQuestion(int id)
        {
            return _questionService.DeleteQuestion(id);
        }
    }
}
