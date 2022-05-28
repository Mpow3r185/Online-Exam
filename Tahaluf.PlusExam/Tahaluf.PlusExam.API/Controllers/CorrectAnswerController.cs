using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectAnswerController : ControllerBase
    {
        private readonly ICorrectAnswerService _correctAnswerService;

        public CorrectAnswerController(ICorrectAnswerService correctAnswerService)
        {
            _correctAnswerService = correctAnswerService;
        }
        //Get All Correct Answer
        [HttpGet]
        [ProducesResponseType(typeof(List<CorrectAnswer>), StatusCodes.Status200OK)]
        public List<CorrectAnswer> GetAll()
        {
            return _correctAnswerService.GetAll();
        }

        //Create
        [HttpPost]
        [ProducesResponseType(typeof(CorrectAnswer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateCorrectAnswer([FromBody] CorrectAnswer correctAnswer)
        {
            return _correctAnswerService.CreateCorrectAnswer(correctAnswer);
        }

        //Update
        [HttpPut]
        [ProducesResponseType(typeof(List<CorrectAnswer>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateCorrectAnswer([FromBody] CorrectAnswer correctAnswer)
        {
            return _correctAnswerService.UpdateCorrectAnswer(correctAnswer);
        }

        //Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public bool DeleteCorrectAnswer(int id)
        {
            return _correctAnswerService.DeleteCorrectAnswer(id);
        }
    }
}
