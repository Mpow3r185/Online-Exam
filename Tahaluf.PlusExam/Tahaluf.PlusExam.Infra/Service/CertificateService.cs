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
        private readonly ICertificateRepository certificateRepository;
        public CertificateService(ICertificateRepository _certificateRepository)
        {
            certificateRepository = _certificateRepository;
        }
        public List<Certificate> GetCertificates()
        {
            return certificateRepository.GetCertificates();
        }
        public bool CreateCertificate(Certificate certificate)
        {
            return certificateRepository.CreateCertificate(certificate);
        }
        public bool UpdateCertificate(Certificate certificate)
        {
            return certificateRepository.UpdateCertificate(certificate);
        }

        public bool DeleteCertificate(int id)
        {
            return certificateRepository.DeleteCertificate(id);
        }

        

       
    }
}
