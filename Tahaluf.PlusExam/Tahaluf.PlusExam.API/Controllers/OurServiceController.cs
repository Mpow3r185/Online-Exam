using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurServiceController : ControllerBase
    {
        #region Fields
        private readonly IOurServiceService _OurServiceService;
        #endregion Fields

        #region Constructor
        public OurServiceController(IOurServiceService OurServiceService)
        {
            _OurServiceService = OurServiceService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetOurService
        [HttpGet]
        public List<OurService> GetOurService()
        {
            return _OurServiceService.GetOurService();
        }
        #endregion GetOurService

        #region CreateOurService
        [HttpPost]
        [ProducesResponseType(typeof(OurService), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateOurService([FromBody] OurService ourService)
        {
            return _OurServiceService.CreateOurService(ourService);
        }
        #endregion CreateOurService

        #region UpdateOurService
        [HttpPut]
        [ProducesResponseType(typeof(List<OurService>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateOurService([FromBody] OurService ourService)
        {
            return _OurServiceService.UpdateOurService(ourService);
        }
        #endregion UpdateOurService

        #region DeleteOurService
        [HttpDelete]
        [Route("DeleteService/{id}")]
        public bool DeleteOurService(int id)
        {
            return _OurServiceService.DeleteOurService(id);
        }
        #endregion DeleteOurService

        #endregion CRUD_Operation
    }
}
