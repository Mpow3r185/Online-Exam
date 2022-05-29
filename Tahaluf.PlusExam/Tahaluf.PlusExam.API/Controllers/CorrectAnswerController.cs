using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CorrectAnswerController : ControllerBase
    {
        #region Fiels
        private readonly ICorrectAnswerService _correctAnswerService;
        #endregion Fiels

        #region Constructor
        public CorrectAnswerController(ICorrectAnswerService correctAnswerService)
        {
            _correctAnswerService = correctAnswerService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCorrectAnswers
        // Get All Correct Answer
        [HttpGet]
        [ProducesResponseType(typeof(List<CorrectAnswer>), StatusCodes.Status200OK)]
        public List<CorrectAnswer> GetCorrectAnswers()
        {
            return _correctAnswerService.GetCorrectAnswers();
        }
        #endregion GetCorrectAnswers

        #region CreateCorrectAnswer
        // Create Correct Answer
        [HttpPost]
        [ProducesResponseType(typeof(CorrectAnswer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateCorrectAnswer([FromBody] CorrectAnswer correctAnswer)
        {
            return _correctAnswerService.CreateCorrectAnswer(correctAnswer);
        }
        #endregion CreateCorrectAnswer

        #region UpdateCorrectAnswer
        // Update Correct Answer
        [HttpPut]
        [ProducesResponseType(typeof(List<CorrectAnswer>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateCorrectAnswer([FromBody] CorrectAnswer correctAnswer)
        {
            return _correctAnswerService.UpdateCorrectAnswer(correctAnswer);
        }
        #endregion UpdateCorrectAnswer

        #region DeleteCorrectAnswer
        // Delete Correct Answer
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteCorrectAnswer(int id)
        {
            return _correctAnswerService.DeleteCorrectAnswer(id);
        }
        #endregion DeleteCorrectAnswer

        #endregion CRUD_Operation
    }
}
