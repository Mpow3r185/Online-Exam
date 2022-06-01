using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        #region Fields
        private readonly IQuestionService _questionService;
        #endregion Fields

        #region Constructor
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetQuestions
        //Get All Questions
        [HttpGet]
        [ProducesResponseType(typeof(List<Question>), StatusCodes.Status200OK)]
        public List<Question> GetQuestions()
        {
            return _questionService.GetQuestions();
        }
        #endregion GetQuestions

        #region CreateQuestion
        // Create Question
        [HttpPost]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateQuestion([FromBody] Question question)
        {
            return _questionService.CreateQuestion(question);
        }
        #endregion CreateQuestion

        #region UpdateQuestion
        // Update Question
        [HttpPut]
        [ProducesResponseType(typeof(List<Question>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateQuestion([FromBody] Question question)
        {
            return _questionService.UpdateQuestion(question);
        }
        #endregion UpdateQuestion

        #region DeleteQuestion
        // Delete Question
        [HttpDelete]
        [Route("DeleteQuestion/{id}")]
        public bool DeleteQuestion(int id)
        {
            return _questionService.DeleteQuestion(id);
        }
        #endregion DeleteQuestion

        #endregion CRUD_Operation
    }
}
