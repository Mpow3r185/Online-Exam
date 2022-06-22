using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class OurServiceRepository : IOurServiceRepository
    {

        #region Fields
        private readonly IGenericCRUD<OurService> genericCRUD;
        #endregion Fields

        #region Constructor
        public OurServiceRepository(IDbContext DbContext)
        {
            genericCRUD = new GenericCRUD<OurService>(DbContext);
        }
        #endregion Constructor

        #region CRUD_Operation
        public bool CreateOurService(OurService ourService)
        {
            return genericCRUD.Create(ourService);
        }

        public bool DeleteOurService(int id)
        {
            return genericCRUD.Delete(id);
        }

        public List<OurService> GetOurService()
        {
            return genericCRUD.GetAll();
        }

        public bool UpdateOurService(OurService ourService)
        {
            return genericCRUD.Update(ourService);
        }
        #endregion CRUD_Operation
    }
}
