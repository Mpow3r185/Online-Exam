using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class DynamicHomeService : IDynamicHomeService
    {
        #region Fields
        private readonly IDynamicHomeRepository dynamicHomeRepository;
        #endregion Fields

        #region Constructor
        public DynamicHomeService(IDynamicHomeRepository _dynamicHomeRepository)
        {
            dynamicHomeRepository = _dynamicHomeRepository;
        }
        #endregion Constructor

        public List<DynamicHome> GetAll()
        {
            return dynamicHomeRepository.GetAll();
        }

        public bool UpdateHome(DynamicHome dynamicHome)
        {
            return dynamicHomeRepository.UpdateHome(dynamicHome);
        }
        
    }
}
