using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly IDbContext dbContext;

        public CertificateRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<Certificate> GetCertificates()
        {
            IEnumerable<Certificate> result = dbContext.Connection.Query<Certificate>("CertificatePackage.GetCertificates", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateCertificate(Certificate certificate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("createDate", certificate.CreatioDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("exam_id", certificate.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("acc_id", certificate.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CertificatePackage.CreateCertificate", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateCertificate(Certificate certificate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CertificateID", certificate.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("createDate", certificate.CreatioDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("exam_id", certificate.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("acc_id", certificate.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CertificatePackage.UpdateCertificate", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCertificate(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CertificateID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CertificatePackage.DeleteCertificate", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

       

        
    }
}
