using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class ResultRepository : IResultRepository
    {
        #region Fields
         private readonly IGenericCRUD<Result> genericCRUD;
        #endregion Fields

        #region Constructor
        public ResultRepository(IDbContext DbContext)
        {
            genericCRUD = new GenericCRUD<Result>(DbContext);
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateResult
        public bool CreateResult(Result result)
        {
           return genericCRUD.Create(result);
        }
        #endregion CreateResult

        #region DeleteResult
        public bool DeleteResult(int id)
        {
           return genericCRUD.Delete(id);
        }
        #endregion DeleteResult

        #region GetResults
        public List<Result> GetResults()
        {
           return genericCRUD.GetAll();
        }
        #endregion GetResults

        #region UpdateResult
        public bool UpdateResult(Result result)
        {
            return genericCRUD.Update(result);
        }
        #endregion UpdateResult

        #endregion CRUD_Operation
    }
}
