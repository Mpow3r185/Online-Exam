using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        #region Fields
        private readonly ICertificateService certificateService;
        #endregion Fields

        #region Constructor
        public CertificateController(ICertificateService _certificateService)
        {
            certificateService = _certificateService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCertificates
        [HttpGet]
        public List<Certificate> GetCertificates()
        {
            return certificateService.GetCertificates();
        }
        #endregion GetCertificates

        #region CreateCertificate
        [HttpPost]
        public bool CreateCertificate(Certificate certificate)
        {
            return certificateService.CreateCertificate(certificate);
        }
        #endregion CreateCertificate

        #region UpdateCertificate
        [HttpPut]
        public bool UpdateCertificate(Certificate certificate)
        {
            return certificateService.UpdateCertificate(certificate);
        }
        #endregion UpdateCertificate

        #region DeleteCertificate
        [HttpDelete]
        [Route("DeleteCertificate/{id}")]
        public bool DeleteCertificate(int id)
        {
            return certificateService.DeleteCertificate(id);
        }
        #endregion DeleteCertificate

        #endregion CRUD_Operation
        
         #region getCertificateByUserId
        [HttpGet]
        [Route("GetCertificateByUserId/{id}")]
        public List<CertificateDTO> getCertificateByUserId(int id)
        {
            return certificateService.getCertificateByUserId(id);
        }
        #endregion getCertificateByUserId
        
    }
}
