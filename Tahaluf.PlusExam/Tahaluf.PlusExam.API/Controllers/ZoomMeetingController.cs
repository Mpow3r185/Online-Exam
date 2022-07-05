using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomMeetingController : ControllerBase
    {
        #region Fields
        private readonly IZoomMeetingService zoomMeetingService;
        #endregion Fields

        #region Constructor
        public ZoomMeetingController(IZoomMeetingService _zoomMeetingService)
        {
            zoomMeetingService = _zoomMeetingService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateZoomMeeting
        [HttpPost]
        public bool CreateZoomMeeting(ZoomMeeting zoomMeeting)
        {
            return zoomMeetingService.CreateZoomMeeting(zoomMeeting);
        }
        #endregion CreateZoomMeeting

        #region DeleteZoomMeeting
        [HttpDelete]
        [Route("deleteZoomMeeting/{zoomId}")]
        public bool DeleteZoomMeeting(int zoomId)
        {
            return zoomMeetingService.DeleteZoomMeeting(zoomId);
        }
        #endregion DeleteZoomMeeting

        #region GetZoomMeetings
        [HttpGet]
        public List<ZoomMeeting> GetZoomMeetings()
        {
            return zoomMeetingService.GetZoomMeetings();
        }
        #endregion GetZoomMeetings

        #region UpdateZoomMeeting
        [HttpPut]
        public bool UpdateZoomMeeting(ZoomMeeting ZoomMeeting)
        {
            return zoomMeetingService.UpdateZoomMeeting(ZoomMeeting);
        }
        #endregion UpdateZoomMeeting

        #endregion CRUD_Operation

        #region GetZoomMeetingByExamId
        [HttpPost]
        [Route("GetZoomMeetingByExamId/{exid}")]
        public ZoomMeeting GetZoomMeetingByExamId(int exid)
        {
            return zoomMeetingService.GetZoomMeetingByExamId(exid);
        }

        #endregion GetZoomMeetingByExamId
    }
}
