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
    public class FillResultRepository : IFillResultRepository
    {
        #region Fields
        private readonly IGenericCRUD<FillResult> genericCRUD;
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public FillResultRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<FillResult>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetFillResults
        public List<FillResult> GetFillResults()
        {
            return genericCRUD.GetAll();
        }

        #endregion GetFillResults

        #region CreateFillResult
        public bool CreateFillResult(FillResult fillResult)
        {
            return genericCRUD.Create(fillResult);
        }
        #endregion CreateFillResult

        #region UpdateFillResult
        public bool UpdateFillResult(FillResult fillResult)
        {
            return genericCRUD.Update(fillResult);
        }
        #endregion UpdateFillResult

        #region DeleteFillResult
        public bool DeleteFillResult(int frid)
        {
            return genericCRUD.Delete(frid);
        }
        #endregion DeleteFillResult

        #endregion CRUD_Operation

        public string GetAnswerByQuestionIdAndAccountId(FillResult fillResult)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("qid",
                fillResult.QuestionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("accid",
                fillResult.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return dbContext.Connection.Query<string>(
                "FillResultPackage.GetAnswerByQuestionIdAndAccountId",
                parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public List<FillResult> GetFillResultByQuestionId(int qid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("qid",
                qid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<FillResult>(
                "FillResultPackage.GetFillResultByQuestionId",
                parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
