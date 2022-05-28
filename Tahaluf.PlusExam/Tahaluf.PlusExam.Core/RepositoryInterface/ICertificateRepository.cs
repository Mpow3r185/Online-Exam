using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface ICertificateRepository
    {
        List<Certificate> GetCertificates();
        bool CreateCertificate(Certificate certificate);
        bool UpdateCertificate(Certificate certificate);
        bool DeleteCertificate(int id);
    }
}
