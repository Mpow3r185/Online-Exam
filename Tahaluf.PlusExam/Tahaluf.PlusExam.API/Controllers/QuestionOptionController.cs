using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class QuestionOptionController : ControllerBase
    {
        #region Fields
        private readonly IQuestionOptionService _questionOptionService;
        #endregion Fields

        #region Constructor
        public QuestionOptionController(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetQuestionsOptions
        // Get QuestionsOptions
        [HttpGet]
        [ProducesResponseType(typeof(List<QuestionOption>), StatusCodes.Status200OK)]
        public List<QuestionOption> GetQuestionsOptions()
        {
            return _questionOptionService.GetQuestionsOptions();
        }
        #endregion GetQuestionsOptions

        #region CreateQuestionOption
        // Create QuestionOption
        [HttpPost]
        [ProducesResponseType(typeof(QuestionOption), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateQuestionOption([FromBody] QuestionOption questionOption)
        {
            return _questionOptionService.CreateQuestionOption(questionOption);
        }
        #endregion CreateQuestionOption

        #region UpdateQuestionOption
        // Update QuestionOption
        [HttpPut]
        [ProducesResponseType(typeof(List<QuestionOption>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateQuestionOption([FromBody] QuestionOption questionOption)
        {
            return _questionOptionService.UpdateQuestionOption(questionOption);
        }
        #endregion UpdateQuestionOption

        #region DeleteQuestionOption
        // Delete QuestionOption
        [HttpDelete]
        [Route("DeleteQuestionOption/{id}")]
        public bool DeleteQuestionOption(int id)
        {
            return _questionOptionService.DeleteQuestionOption(id);
        }
        #endregion DeleteQuestionOption

        #endregion CRUD_Operation
    }
}
