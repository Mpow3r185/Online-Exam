using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class ReportRepository : IReportRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public ReportRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        // Get Number of Users
        public List<AllUsersDTO> NumberOfUsers()
        {
            IEnumerable<AllUsersDTO> result = dbContext.Connection.Query<AllUsersDTO>("ReportPackage.NumOfUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        
        // Get Total exam's cost for all Courses
        public List<TotalCostDTO> TotalCost()
        {
            IEnumerable<TotalCostDTO> result = dbContext.Connection.Query<TotalCostDTO>("ReportPackage.TotalCost", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // Get Total exam's cost by CourseName
        public TotalCostDTO TotalCostByCourseName(string name)
        {
            var p = new DynamicParameters();
            p.Add("cName", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<TotalCostDTO> result = dbContext.Connection.Query<TotalCostDTO>("ReportPackage.TotalExamsCostByCourseName", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        // Get Number of users by CourseName
        public AllUsersDTO NumberOfUsersByCourseName(string name)
        {
            var p = new DynamicParameters();
            p.Add("cName", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<AllUsersDTO> result = dbContext.Connection.Query<AllUsersDTO>("ReportPackage.GetNumOfUsersByCourseName", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        // Get Number of users by ExamName
        public AllUsersDTO NumberOfUsersByExmaName(string name)
        {
            var p = new DynamicParameters();
            p.Add("eName", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<AllUsersDTO> result = dbContext.Connection.Query<AllUsersDTO>("ReportPackage.GetNumOfUsersByExamName", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        // Get Number Of Certificates
        public AllUsersDTO NumberOfCertificates()
        {    
            IEnumerable<AllUsersDTO> result = dbContext.Connection.Query<AllUsersDTO>("ReportPackage.GetNumOfCertificate", commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
    }
}
