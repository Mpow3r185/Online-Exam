using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService certificateService;

        public CertificateController(ICertificateService _certificateService)
        {
            certificateService = _certificateService;
        }
        [HttpGet]
        public List<Certificate> GetCertificates()
        {
            return certificateService.GetCertificates();
        }
        [HttpPost]
        public bool CreateCertificate(Certificate certificate)
        {
            return certificateService.CreateCertificate(certificate);
        }
        [HttpPut]
        public bool UpdateCertificate(Certificate certificate)
        {
            return certificateService.UpdateCertificate(certificate);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCertificate(int id)
        {
            return certificateService.DeleteCertificate(id);
        }
    }
}
