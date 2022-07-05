using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IZoomMeetingRepository
    {
        // Get Zoom Meetings
        List<ZoomMeeting> GetZoomMeetings();

        // Create Zoom Meetings
        bool CreateZoomMeeting(ZoomMeeting zoomMeeting);

        // Update Zoom Meeting
        bool UpdateZoomMeeting(ZoomMeeting zoomMeeting);

        // Delete Zoom Meetings
        bool DeleteZoomMeeting(int zoomId);

        // Get Zoom Meeting By Exam Id
        ZoomMeeting GetZoomMeetingByExamId(int examId);
    }
}
