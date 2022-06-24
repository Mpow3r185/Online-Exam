using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        #region Fields
        private readonly IExamService examService;
        #endregion Fields

        #region Constructor
        public ExamController(IExamService _examService)
        {
            examService = _examService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateExam
        [HttpPost]
        public bool CreateExam(Exam exam)
        {
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
    }
}
