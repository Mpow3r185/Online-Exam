using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Infra.Generic;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        #region Fields
        private readonly IGenericCRUD<Question> genericCRUD;
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public QuestionRepository(IDbContext DbContext)
        {
            genericCRUD = new GenericCRUD<Question>(DbContext);  
            dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateQuestion
        public bool CreateQuestion(Question question)
        {
            return genericCRUD.Create(question);
        }
        #endregion CreateQuestion

        #region DeleteQuestion
        public bool DeleteQuestion(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteQuestion

        #region GetQuestions
        public List<Question> GetQuestions()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetQuestions

        #region UpdateQuestion
        public bool UpdateQuestion(Question question)
        {
            return genericCRUD.Update(question);
        }
        #endregion UpdateQuestion

        #endregion CRUD_Operation

        public List<Question> GetQeustionsByExamId(int exid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("exid",
                exid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<Question>(
                "QuestionPackage.GetQeustionsByExamId", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }
        
        // Get Qeustions Details ByExamId
        public List<QuestionsDetailsDTO> GetQeustionsDetailsByExamId(int exid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("exid",
                exid,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            return dbContext.Connection.Query<QuestionsDetailsDTO>(
                "QuestionPackage.GetQeustionsDetailsByExamId", parameters,
                commandType: CommandType.StoredProcedure).ToList();
        }

        // Get All Questions Details 
        public List<QuestionsDetailsDTO> GetAllQeustionsDetails()
        {
            IEnumerable<QuestionsDetailsDTO> result = dbContext.Connection.Query<QuestionsDetailsDTO>(
                "QuestionPackage.GetAllQuestionsDetails",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        // Get Questions And Exams
        public List<QuestionExamDTO> GetQuestionsAndExams()
        {
            return dbContext.Connection.Query<QuestionExamDTO>(
                "QuestionPackage.GetQuestionsAndExams",
                commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
