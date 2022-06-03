using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        #region Fields
        private readonly IReportService reportService;
        #endregion Fields

        #region Constructor
        public ReportController(IReportService _reportService)
        {
            reportService = _reportService;
        }
        #endregion Constructor


        // Get Number of Users
        [HttpGet]
        [Route("NumberOfUsers")]
        public List<AllUsersDTO> NumberOfUsers()
        {
            return reportService.NumberOfUsers();   
        }

        // Get Total exam's cost for all Courses
        [HttpGet]
        [Route("TotalCost")]
        public List<TotalCostDTO> TotalCost()
        {
            return reportService.TotalCost();
        }


        // Get Total exam's cost by CourseName
        [HttpPost]
        [Route("TotalCostByCourseName/{name}")]
        public TotalCostDTO TotalCostByCourseName(string name)
        {
            return reportService.TotalCostByCourseName(name);
        }

        // Get Number of users by CourseName
        [HttpPost]
        [Route("NumberOfUsersByCourseName/{name}")]
        public AllUsersDTO NumberOfUsersByCourseName(string name)
        {
            return reportService.NumberOfUsersByCourseName(name);
        }

        // Get Number of users by ExamName
        [HttpPost]
        [Route("NumberOfUsersByExmaName/{name}")]
        public AllUsersDTO NumberOfUsersByExmaName(string name)
        {
            return reportService.NumberOfUsersByExmaName(name);
        }

        //Get Number of Certificates
        [HttpGet]
        [Route("NumberOfCertificates")]
        public AllUsersDTO NumberOfCertificates()
        {
            return reportService.NumberOfCertificates();    
        }


    }
}
