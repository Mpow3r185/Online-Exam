using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface ICertificateService
    {
        // Get Certificates
        List<Certificate> GetCertificates();


        // Create Certificate
        bool CreateCertificate(Certificate certificate);


        // Update Certificate
        bool UpdateCertificate(Certificate certificate);

        // Delete Certificate
        bool DeleteCertificate(int id);
        
        //Get Certificate By User Id
        List<CertificateDTO> getCertificateByUserId(int id);
    }
}
