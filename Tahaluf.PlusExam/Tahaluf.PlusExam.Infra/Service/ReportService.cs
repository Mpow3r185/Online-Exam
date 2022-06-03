using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class ReportService : IReportService
    {
        #region Fields
        private readonly IReportRepository reportRepository;
        #endregion Fields

        #region Constructor
        public ReportService(IReportRepository _reportRepository)
        {
            reportRepository = _reportRepository;
        }
        #endregion Constructor

        // Get Number of Users
        public List<AllUsersDTO> NumberOfUsers()
        {
            return reportRepository.NumberOfUsers();
        }

       
        // Get Total exam's cost for all Courses
        public List<TotalCostDTO> TotalCost()
        {
            return reportRepository.TotalCost();
        }

        // Get Total exam's cost by CourseName
        public TotalCostDTO TotalCostByCourseName(string name)
        {
            return reportRepository.TotalCostByCourseName(name);
        }

        // Get Number of users by CourseName
        public AllUsersDTO NumberOfUsersByCourseName(string name)
        {
            return reportRepository.NumberOfUsersByCourseName(name);
        }

        // Get Number of users by ExamName
        public AllUsersDTO NumberOfUsersByExmaName(string name)
        {
            return reportRepository.NumberOfUsersByExmaName(name);
        }

        // Get Number Of Certificates
        public AllUsersDTO NumberOfCertificates()
        {
            return reportRepository.NumberOfCertificates();
        }
    }
}
