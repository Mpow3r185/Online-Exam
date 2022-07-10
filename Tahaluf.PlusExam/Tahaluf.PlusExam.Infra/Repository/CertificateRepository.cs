using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<Certificate> genericCRUD;
        #endregion Fields

        #region Constructor
        public CertificateRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<Certificate>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCertificates
        public List<Certificate> GetCertificates()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetCertificates

        #region CreateCertificate
        public bool CreateCertificate(Certificate certificate)
        { 

            return genericCRUD.Create(certificate);
        }
        #endregion CreateCertificate

        #region UpdateCertificate
        public bool UpdateCertificate(Certificate certificate)
        {

            return genericCRUD.Update(certificate);
        }
        #endregion UpdateCertificate

        #region DeleteCertificate
        public bool DeleteCertificate(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteCertificate

        #endregion CRUD_Operation
        
        #region getCertificateByUserId
        public List<CertificateDTO> getCertificateByUserId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("uid",
                id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<CertificateDTO>(
                "CertificatePackage.getCertificateByUserId", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion getCertificateByUserId
        
    }
}
