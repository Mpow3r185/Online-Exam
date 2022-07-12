using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        #region Fields
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _questionOptionService;
        private readonly ICorrectAnswerService _correctAnswerService;
        #endregion Fields

        #region Constructor
        public QuestionController(IQuestionService questionService, IQuestionOptionService questionOptionService, ICorrectAnswerService correctAnswerService)
        {
            _questionService = questionService;
            _questionOptionService = questionOptionService;
            _correctAnswerService = correctAnswerService;
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

        #region GetQeustionsByExamId
        [HttpPost]
        [Route("GetQeustionsByExamId/{exid}")]
        public List<Question> GetQeustionsByExamId(int exid)
        {
            return _questionService.GetQeustionsByExamId(exid);
        }
        #endregion GetQeustionsByExamId

        [HttpPost]
        [Route("CreateExamQuestions/{exid}")]
        public bool CreateExamQuestions(int exid, [FromBody] ExamQuestionsDTO[] examQuestionsDTOs)
        {
            foreach (ExamQuestionsDTO examQuestionDTO in examQuestionsDTOs)
            {
                Question question = new Question();
                question.Status = examQuestionDTO.Status;
                question.Type = examQuestionDTO.Type;
                question.Score = examQuestionDTO.Score;
                question.QuestionContent = examQuestionDTO.Text;
                question.ExamId = exid;

                _questionService.CreateQuestion(question);  // Create Question
                int qid = _questionService.GetQeustionsByExamId(exid).Find(q => q.QuestionContent == question.QuestionContent && question.Type == q.Type).Id;

                if (examQuestionDTO.Type == "Fill")
                {
                    QuestionOption questionOption = new QuestionOption();
                    questionOption.QuestionId = qid;
                    questionOption.OptionContent = examQuestionDTO.FillOption.OptionContent;

                    _questionOptionService.CreateQuestionOption(questionOption);  // Create Question Option
                } else
                {
                    foreach (ChooseOptionDTO chooseOptionDTO in examQuestionDTO.Options)
                    {
                        QuestionOption questionOption = new QuestionOption();
                        questionOption.QuestionId = qid;
                        questionOption.OptionContent = chooseOptionDTO.OptionContent;

                        _questionOptionService.CreateQuestionOption(questionOption);  // Create Question Option

                        if (chooseOptionDTO.IsCorrectOption)
                        {
                            int qOptionId = _questionOptionService.GetQuestionOptionByQuestionId(qid).Find(qop => qop.OptionContent == chooseOptionDTO.OptionContent).Id;
                            CorrectAnswer correctAnswer = new CorrectAnswer();
                            correctAnswer.QuestionOptionId = qOptionId; 

                            _correctAnswerService.CreateCorrectAnswer(correctAnswer);  // Create Correct Answer
                        }
                    }
                    
                }
            }

            return true;
        }
    }
}
