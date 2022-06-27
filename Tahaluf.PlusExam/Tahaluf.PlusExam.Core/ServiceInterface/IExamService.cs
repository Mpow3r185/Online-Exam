using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IExamService
    {
        // Get Exams
        List<Exam> GetExams();

        // Create Exam
        bool CreateExam(Exam exam);

        // Update Exam
        bool UpdateExam(Exam exam);

        // Delete Exam
        bool DeleteExam(int exid);

        // Search Exam
        List<Exam> SearchExam(ExamFilter examFilter);

        // Get Exams By Course Id
        List<Exam> GetExamsByCourseId(int cid);

        // Get Exam By Id
        Exam GetExamById(int exid);
    }
}
