
using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class OurServiceService : IOurServiceService
    {

        #region Fields
        private readonly IOurServiceRepository _ourServiceRepository;
        #endregion Fields

        #region Constructor
        public OurServiceService(IOurServiceRepository ourServiceRepository)
        {
            _ourServiceRepository = ourServiceRepository;
        }
        #endregion Constructor

        #region CRUD_Operation
        public bool CreateOurService(OurService ourService)
        {
            return _ourServiceRepository.CreateOurService(ourService);
        }

        public bool DeleteOurService(int id)
        {
            return _ourServiceRepository.DeleteOurService(id);
        }

        public List<OurService> GetOurService()
        {
            return _ourServiceRepository.GetOurService();
        }

        public bool UpdateOurService(OurService ourService)
        {
            return _ourServiceRepository.UpdateOurService(ourService);
        }
        #endregion CRUD_Operation
    }
}
