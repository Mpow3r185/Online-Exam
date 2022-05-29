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
        private readonly IExamRepository examRepository;

        public ExamService(IExamRepository _examRepository)
        {
            examRepository = _examRepository;
        }

        public bool CreateExam(Exam exam)
        {
            return examRepository.CreateExam(exam);
        }

        public bool DeleteExam(int exid)
        {
            return examRepository.DeleteExam(exid);
        }

        public List<Exam> GetExams()
        {
            return examRepository.GetExams();
        }

        public List<Exam> SearchExam(ExamFilter examFilter)
        {
            return examRepository.SearchExam(examFilter);
        }

        public bool UpdateExam(Exam exam)
        {
            return examRepository.UpdateExam(exam);
        }
    }
}
