using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;
using Tahaluf.PlusExam.Infra.Service;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        #region Fields
        private readonly IExamService examService;
        private readonly IQuestionService questionService;
        private readonly IQuestionOptionService questionOptionService;
        #endregion Fields

        #region Constructor
        public ExamController(IExamService _examService, IQuestionService _questionService, IQuestionOptionService _questionOptionService)
        {
            examService = _examService;
            questionService = _questionService;
            questionOptionService = _questionOptionService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateExam
        [HttpPost]
        public bool CreateExam(Exam exam)
        {
            string passcode, pass;
            do
            {
                passcode = GenerateRandomPasscode();
                pass = GetExams().Select(exam => exam.Passcode).FirstOrDefault(passc => passc == passcode);
            } while (!(pass is null));
            exam.Passcode = passcode;
            exam.CreationDate = DateTime.Now;

            return examService.CreateExam(exam);
        }
        #endregion CreateExam

        #region DeleteExam
        [HttpDelete]
        [Route("deleteExam/{exid}")]
        public bool DeleteExam(int exid)
        {
            return examService.DeleteExam(exid);
        }
        #endregion DeleteExam

        #region GetExams
        [HttpGet]
        public List<Exam> GetExams()
        {
            return examService.GetExams();
        }
        #endregion GetExams

        #region UpdateExam
        [HttpPut]
        public bool UpdateExam(Exam exam)
        {
            return examService.UpdateExam(exam);
        }
        #endregion UpdateExam

        #endregion CRUD_Operation

        #region SearchExam
        [HttpPost]
        [Route("searchExam")]
        public List<Exam> SearchExam(ExamFilter examFilter)
        {
            return examService.SearchExam(examFilter);
        }
        #endregion SearchExam

        #region GetExamsByCourseId
        [HttpPost]
        [Route("GetExamsByCourseId/{cid}")]
        public List<Exam> GetExamsByCourseId(int cid)
        {
            return examService.GetExamsByCourseId(cid);
        }
        #endregion GetExamsByCourseId

        #region GetExamById
        [HttpPost]
        [Route("GetExamById/{exid}")]
        public Exam GetExamById(int exid)
        {
            return examService.GetExamById(exid);
        }
        #endregion GetExamById

        #region GetUsersBuyExamId
        [HttpPost]
        [Route("GetUsersBuyExamId/{exid}")]
        public List<Account> GetUsersBuyExamId(int exid)
        {
            return examService.GetUsersBuyExamId(exid);
        }
        #endregion GetUsersBuyExamId

        #region CheckIfUserBuyExam
        [HttpPost]
        [Route("CheckIfUserBuyExam")]
        public bool CheckIfUserBuyExam(CheckBuyExamDTO data)
        {
            List<Account> account = examService.GetUsersBuyExamId(data.ExamId).Where((account) => account.Id == data.AccountId).ToList();
             return (account.Count > 0) ? true : false;
        }
        #endregion CheckIfUserBuyExam

        #region GetNumberOfUsersBuyByExamId
        [HttpPost]
        [Route("GetNumberOfUsersBuyByExamId/{exid}")]
        public int GetNumberOfUsersBuyByExamId(int exid)
        {
            return examService.GetNumberOfUsersBuyByExamId(exid);
        }
        #endregion GetNumberOfUsersBuyByExamId

        
        [HttpPost]
        [Route("getExamContent/{exid}")]
        public List<QuestionContentDTO> getExamContent(int exid)
        {
            List<Question> questions = this.questionService.GetQeustionsByExamId(exid);
            List<QuestionContentDTO> questionContentDTOs = new List<QuestionContentDTO>(questions.Count);

            foreach(Question question in questions)
            {
                if (question.Status == "ENABLE")
                {
                    QuestionContentDTO questionContentDTO = new QuestionContentDTO();
                    questionContentDTO.Question = question;
                    questionContentDTO.Options = questionOptionService.GetQuestionOptionByQuestionId(question.Id);
                    questionContentDTOs.Add(questionContentDTO);
                }
            }

            List<QuestionContentDTO> randomQuestions = new List<QuestionContentDTO>(GetExamById(exid).NumberOfQuestions);
            List<int> qIsAvailable = Enumerable.Range(0, questionContentDTOs.Count).ToList();
            Random random = new Random();

            while(randomQuestions.Count < randomQuestions.Capacity)
            {
                int randomIndex = random.Next(0, qIsAvailable.Count);
                randomQuestions.Add(questionContentDTOs[qIsAvailable[randomIndex]]);
                qIsAvailable.RemoveAt(randomIndex);
            }

            return randomQuestions;
        }

        private string GenerateRandomPasscode()
        {
            Random random = new Random();
            string alpha = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            int randomLength = random.Next(4, 8);

            string passcode = "";
            for (int i = 0; i < randomLength; i++)
            {
                int randomIndex = random.Next(alpha.Length);
                passcode += alpha[randomIndex];
            }

            return passcode;
        }
    }
}
