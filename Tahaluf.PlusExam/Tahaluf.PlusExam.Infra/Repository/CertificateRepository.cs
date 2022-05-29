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
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public CertificateRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCertificates
        public List<Certificate> GetCertificates()
        {
            return dbContext.Connection.Query<Certificate>(
                "CertificatePackage.GetCertificates",
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetCertificates

        #region CreateCertificate
        public bool CreateCertificate(Certificate certificate)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("createDate",
                certificate.CreatioDate, 
                dbType: DbType.DateTime, 
                direction: ParameterDirection.Input);

            parameters.Add("exam_id", 
                certificate.ExamId, 
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("acc_id", 
                certificate.AccountId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "CertificatePackage.CreateCertificate", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateCertificate

        #region UpdateCertificate
        public bool UpdateCertificate(Certificate certificate)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CertificateID", 
                certificate.Id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("createDate", 
                certificate.CreatioDate, 
                dbType: DbType.DateTime, 
                direction: ParameterDirection.Input);

            parameters.Add("exam_id", 
                certificate.ExamId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("acc_id", 
                certificate.AccountId, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            dbContext.Connection.ExecuteAsync(
                "CertificatePackage.UpdateCertificate", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateCertificate

        #region DeleteCertificate
        public bool DeleteCertificate(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CertificateID", 
                id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            dbContext.Connection.ExecuteAsync(
                "CertificatePackage.DeleteCertificate", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteCertificate

        #endregion CRUD_Operation
    }
}
