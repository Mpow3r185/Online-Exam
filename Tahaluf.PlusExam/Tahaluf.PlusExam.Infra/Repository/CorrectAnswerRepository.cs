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
    public class CorrectAnswerRepository : ICorrectAnswerRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<CorrectAnswer> genericCRUD;
        #endregion Fields

        #region Constructor
        public CorrectAnswerRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<CorrectAnswer>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetCorrectAnswers
        // Get Correct Answers
        public List<CorrectAnswer> GetCorrectAnswers()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetCorrectAnswers

        #region CreateCorrectAnswer
        // Create CorrectAnswer
        public bool CreateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            return genericCRUD.Create(correctAnswer);
        }
        #endregion CreateCorrectAnswer

        #region UpdateCorrectAnswer
        // Update CorrectAnswer
        public bool UpdateCorrectAnswer(CorrectAnswer correctAnswer)
        {
            return genericCRUD.Update(correctAnswer);
        }
        #endregion UpdateCorrectAnswer

        #region DeleteCorrectAnswer
        // Delete CorrectAnswer
        public bool DeleteCorrectAnswer(int id)
        {
            return genericCRUD.Delete(id);
        }
        #endregion DeleteCorrectAnswer

        #endregion CRUD_Operation
    }
}
