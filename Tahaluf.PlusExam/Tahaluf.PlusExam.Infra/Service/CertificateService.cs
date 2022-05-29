using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class CertificateService : ICertificateService
    {
        #region Fields
        private readonly ICertificateRepository certificateRepository;
        #endregion Fields

        #region Constructor
        public CertificateService(ICertificateRepository _certificateRepository)
        {
            certificateRepository = _certificateRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCertificates
        public List<Certificate> GetCertificates()
        {
            return certificateRepository.GetCertificates();
        }
        #endregion GetCertificates

        #region CreateCertificate
        public bool CreateCertificate(Certificate certificate)
        {
            return certificateRepository.CreateCertificate(certificate);
        }
        #endregion CreateCertificate

        #region UpdateCertificate
        public bool UpdateCertificate(Certificate certificate)
        {
            return certificateRepository.UpdateCertificate(certificate);
        }
        #endregion UpdateCertificate

        #region DeleteCertificate
        public bool DeleteCertificate(int id)
        {
            return certificateRepository.DeleteCertificate(id);
        }
        #endregion DeleteCertificate

        #endregion CRUD_Operation
    }
}
