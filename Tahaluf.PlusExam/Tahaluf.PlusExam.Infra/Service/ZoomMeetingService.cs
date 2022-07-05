using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class ZoomMeetingService : IZoomMeetingService
    {
        #region Fields
        private readonly IZoomMeetingRepository zoomMeetingRepository;
        #endregion Fields

        #region Constructor
        public ZoomMeetingService(IZoomMeetingRepository _zoomMeetingRepository)
        {
            zoomMeetingRepository = _zoomMeetingRepository;
        }
        #endregion Constructor

        #region CRUD_Operation
        public bool CreateZoomMeeting(ZoomMeeting zoomMeeting)
        {
            return zoomMeetingRepository.CreateZoomMeeting(zoomMeeting);
        }

        public bool DeleteZoomMeeting(int zoomId)
        {
            return zoomMeetingRepository.DeleteZoomMeeting(zoomId);
        }

        public List<ZoomMeeting> GetZoomMeetings()
        {
            return zoomMeetingRepository.GetZoomMeetings();
        }

        public bool UpdateZoomMeeting(ZoomMeeting zoomMeeting)
        {
            return zoomMeetingRepository.UpdateZoomMeeting(zoomMeeting);
        }
        #endregion CRUD_Operation

        public ZoomMeeting GetZoomMeetingByExamId(int examId)
        {
            return zoomMeetingRepository.GetZoomMeetingByExamId(examId);
        }
    }
}
