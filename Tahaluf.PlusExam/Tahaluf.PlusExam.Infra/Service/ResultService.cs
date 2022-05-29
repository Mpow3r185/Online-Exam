using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class ResultService : IResultService
    {
        #region Fields
        private readonly IResultRepository _resultRepository;
        #endregion Fields

        #region Constructor
        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateResult
        public bool CreateResult(Result result)
        {
            return _resultRepository.CreateResult(result);
        }
        #endregion CreateResult

        #region DeleteResult
        public bool DeleteResult(int id)
        {
            return _resultRepository.DeleteResult(id);
        }
        #endregion DeleteResult

        #region GetResults
        public List<Result> GetResults()
        {
            return _resultRepository.GetResults();
        }
        #endregion GetResults

        #region UpdateResult
        public bool UpdateResult(Result result)
        {
            return _resultRepository.UpdateResult(result);
        }
        #endregion UpdateResult

        #endregion CRUD_Operation
    }
}
