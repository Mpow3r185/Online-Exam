using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class ZoomMeetingRepository: IZoomMeetingRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<ZoomMeeting> genericCRUD;
        #endregion Fields

        #region Constructor
        public ZoomMeetingRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<ZoomMeeting>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetZoomMeetings
        public List<ZoomMeeting> GetZoomMeetings()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetAccounts

        #region CreateZoomMeeting
        public bool CreateZoomMeeting(ZoomMeeting zoomMeeting)
        {
            return genericCRUD.Create(zoomMeeting);
        }
        #endregion CreateAccount

        #region UpdateZoomMeeting
        public bool UpdateZoomMeeting(ZoomMeeting zoomMeeting)
        {
            return genericCRUD.Update(zoomMeeting);
        }
        #endregion UpdateAccount

        #region DeleteZoomMeeting
        public bool DeleteZoomMeeting(int zoomId)
        {
            return genericCRUD.Delete(zoomId);
        }
        #endregion DeleteAccount

        #endregion CRUD_Operation

        public ZoomMeeting GetZoomMeetingByExamId(int examId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("exid",
                examId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<ZoomMeeting>(
                "ZoomMeetingPackage.GetZoomMeetingByExamId", parameters,
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
