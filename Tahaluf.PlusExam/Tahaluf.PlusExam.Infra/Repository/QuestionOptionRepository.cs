﻿using Dapper;
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
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        #region Fields
        private readonly IGenericCRUD<QuestionOption> genericCRUD;
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public QuestionOptionRepository(IDbContext DbContext)
        {
            genericCRUD = new GenericCRUD<QuestionOption>(DbContext);
            dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestionOption
        public bool CreateQuestionOption(QuestionOption questionOption)
        {
            return genericCRUD.Create(questionOption);
        }
        #endregion CreateQuestionOption

        #region DeleteQuestionOption
        public bool DeleteQuestionOption(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteQuestionOption

        #region GetQuestionsOptions
        public List<QuestionOption> GetQuestionsOptions()
        {
           return genericCRUD.GetAll();
        }
        #endregion GetQuestionsOptions

        #region UpdateQuestionOption
        public bool UpdateQuestionOption(QuestionOption questionOption)
        {
            return genericCRUD.Update(questionOption);
        }
        #endregion UpdateQuestionOption

        #endregion CRUD_Operation
        
        public List<QuestionOption> GetQuestionOptionByQuestionId(int qid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("qid",
                qid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<QuestionOption>(
                "QuestionOptionPackage.GetQuestionOptionByQuestionId", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
