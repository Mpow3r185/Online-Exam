using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface ICertificateService
    {
        List<Certificate> GetCertificates();
        bool CreateCertificate(Certificate certificate);
        bool UpdateCertificate(Certificate certificate);
        bool DeleteCertificate(int id);
    }
}
