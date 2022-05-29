using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class ExamService : IExamService
    {
        #region Fields
        private readonly IExamRepository examRepository;
        #endregion Fields

        #region Constructor
        public ExamService(IExamRepository _examRepository)
        {
            examRepository = _examRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateExam
        public bool CreateExam(Exam exam)
        {
            return examRepository.CreateExam(exam);
        }
        #endregion CreateExam

        #region DeleteExam
        public bool DeleteExam(int exid)
        {
            return examRepository.DeleteExam(exid);
        }
        #endregion DeleteExam

        #region GetExams
        public List<Exam> GetExams()
        {
            return examRepository.GetExams();
        }
        #endregion GetExams

        #region UpdateExam
        public bool UpdateExam(Exam exam)
        {
            return examRepository.UpdateExam(exam);
        }
        #endregion UpdateExam

        #endregion CRUD_Operation

        public List<Exam> SearchExam(ExamFilter examFilter)
        {
            return examRepository.SearchExam(examFilter);
        }
    }
}
