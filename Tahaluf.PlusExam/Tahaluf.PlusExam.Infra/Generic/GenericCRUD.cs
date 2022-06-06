using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.GenericInterface;
using Tahaluf.PlusExam.Infra.Commom;

namespace Tahaluf.PlusExam.Infra.Generic
{
    public class GenericCRUD<T> : IGenericCRUD<T> where T : class
    {
        private readonly IDbContext dbContext;
        private readonly string type;
        
        public GenericCRUD(IDbContext _dbContext)
        {
            dbContext = _dbContext;
            type = typeof(T).Name;
        }

        public bool Create(T entity)
        {
             switch (type)
            {
                // Account Table
                case "Account":
                    {
                        DynamicParameters accountDynamicParameters = GenerateAccountParameters(entity);
                        accountDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "AccountPackage.AccountCRUD", accountDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // Question Table
                case "Question":
                    {
                        DynamicParameters questionDynamicParameters = GenerateQuestionParameters(entity);
                        questionDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionPackage.QuestionCRUD", questionDynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;
                    }

                // QuestionOption Table
                case "QuestionOption":
                    {
                        DynamicParameters questionOptionDynamicParameters = GenerateQuestionOptionParameters(entity);
                        questionOptionDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionOptionPackage.QuestionOptionCRUD", questionOptionDynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;
                    }

                // Result Table
                case "Result":
                    {
                        DynamicParameters resultDynamicParameters = GenerateResultParameters(entity);
                        resultDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "ResultPackage.ResultCRUD", resultDynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;
                    }

                // Course Table
                case "Course":
                    {
                        DynamicParameters courseDynamicParameters = GenerateCourseParameters(entity);
                        courseDynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CoursePackage.CourseCRUD", courseDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // Exam Table
                case "Exam":
                    {
                        DynamicParameters examDynamicParameters = GenerateExamParameters(entity);
                        examDynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "ExamPackage.ExamCRUD", examDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // FillResult Table
                case "FillResult":
                    {
                        DynamicParameters fillResultDynamicParameters = GenerateFillResultParameters(entity);
                        fillResultDynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "FillResultPackage.FillResultCRUD", fillResultDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
            }
            return true;
        }

        public bool Delete(int id)
        {
             switch (type)
            {
                // Account Table
                case "Account":
                    {
                        DynamicParameters accountDynamicParameters = new DynamicParameters();
                        accountDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        accountDynamicParameters.Add("accid",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "AccountPackage.AccountCRUD",
                            accountDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // Question Table
                case "Question":
                    {
                        DynamicParameters questionDynamicParameters = new DynamicParameters();
                        questionDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);
                        questionDynamicParameters.Add("Qid",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionPackage.QuestionCRUD", questionDynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;
                    }

                // QuestionOption Table
                case "QuestionOption":
                    {
                        DynamicParameters questionOptionDynamicParameters = new DynamicParameters();
                        questionOptionDynamicParameters.Add("func",
                            "DELETE",
                            dbType: DbType.String);
                        questionOptionDynamicParameters.Add("Oid",
                          id,
                          dbType: DbType.Int32,
                          direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionOptionPackage.QuestionOptionCRUD",
                            questionOptionDynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;
                    }

                // Result Table
                case "Result":
                    {
                        DynamicParameters resultDynamicParameters = new DynamicParameters();
                        resultDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);
                        resultDynamicParameters.Add("Rid",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "ResultPackage.ResultCRUD",
                            resultDynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;
                    }

                // Course Table
                case "Course":
                    {
                        DynamicParameters courseDynamicParameters = new DynamicParameters();
                        courseDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        courseDynamicParameters.Add("cid",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CoursePackage.CourseCRUD",
                            courseDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // Exam Table
                case "Exam":
                    {
                        DynamicParameters examDynamicParameters = new DynamicParameters();
                        examDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        examDynamicParameters.Add("exid",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "ExamPackage.ExamCRUD",
                            examDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // FillResult Table
                case "FillResult":
                    {
                        DynamicParameters fillResultDynamicParameters = new DynamicParameters();
                        fillResultDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        fillResultDynamicParameters.Add("frid",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "FillResultPackage.FillResultCRUD",
                            fillResultDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
            }
            return true;
        }

        public dynamic GetAll()
        {
            switch (type)
            {
                // Account Table
                case "Account":
                    {
                        return dbContext.Connection.Query<Account>(
                            "AccountPackage.AccountCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }

                // Question Table
                case "Question":
                    {
                        return dbContext.Connection.Query<Question>(
                       "QuestionPackage.QuestionCRUD",
                       commandType: CommandType.StoredProcedure).ToList();
                    }

                // QuestionOption Table
                case "QuestionOption":
                    {
                        return dbContext.Connection.Query<QuestionOption>(
                        "QuestionOptionPackage.QuestionOptionCRUD",
                        commandType: CommandType.StoredProcedure).ToList();
                    }

                // Result Table
                case "Result":
                    {
                        return dbContext.Connection.Query<Result>(
                       "ResultPackage.ResultCRUD",
                       commandType: CommandType.StoredProcedure).ToList();
                    }

                // Course Table
                case "Course":
                    {
                        return dbContext.Connection.Query<Course>(
                            "CoursePackage.CourseCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }

                // Exam Table
                case "Exam":
                    {
                        return dbContext.Connection.Query<Exam>(
                            "ExamPackage.ExamCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }

                // FillResult Table
                case "FillResult":
                    {
                        return dbContext.Connection.Query<FillResult>(
                            "FillResultPackage.FillResultCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
            }

            return null;
        }

        public bool Update(T entity)
        {
            switch (type)
            {
                // Account Table
                case "Account":
                    {
                        DynamicParameters accountDynamicParameters = GenerateAccountParameters(entity);
                        accountDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "AccountPackage.AccountCRUD", accountDynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        
                        return true;
                    }

                // Question Table
                case "Question":
                    {
                        DynamicParameters questionDynamicParameters = GenerateQuestionParameters(entity);
                        questionDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionPackage.QuestionCRUD", questionDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // QuestionOption Table
                case "QuestionOption":
                    {
                        DynamicParameters questionOptionDynamicParameters = GenerateQuestionOptionParameters(entity);
                        questionOptionDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionOptionPackage.QuestionOptionCRUD", questionOptionDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // Result Table
                case "Result":
                    {
                        DynamicParameters resultDynamicParameters = GenerateResultParameters(entity);
                        resultDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "ResultPackage.ResultCRUD", resultDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // Course Table
                case "Course":
                    {
                        DynamicParameters courseDynamicParameters = GenerateCourseParameters(entity);
                        courseDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "CoursePackage.CourseCRUD", courseDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // Exam Table
                case "Exam":
                    {
                        DynamicParameters examDynamicParameters = GenerateCourseParameters(entity);
                        examDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "ExamPackage.ExamCRUD", examDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }

                // FillResult Table
                case "FillResult":
                    {
                        DynamicParameters fillResultDynamicParameters = GenerateCourseParameters(entity);
                        fillResultDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "FillResultPackage.FillResultCRUD", fillResultDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
            }
            return true;
        }

        // Dynamic Parameters For Account tabel 
        private DynamicParameters GenerateAccountParameters(dynamic account)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("accid",
                account.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("uName",
                account.Username,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("passw",
                account.Password,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("mail",
                account.Email,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("fName",
                account.Fullname,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("sex",
                account.Gender,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("birthOfDate",
                account.Bod,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("addr",
                account.Address,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                account.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("rName",
                account.Rolename,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("profileImg",
                account.ProfilePicture,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }
        
        // Dynamic Parameters For Question tabel 
        private DynamicParameters GenerateQuestionParameters(dynamic question)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Qid",
               question.Id,
               dbType: DbType.Int32,
               direction: ParameterDirection.Input);

            parameters.Add("QContent",
                question.QuestionContent,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("QType",
                question.Type,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("QScore",
                question.Score,
                dbType: DbType.Double,
                direction: ParameterDirection.Input);

            parameters.Add("QStatues",
                question.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("QExamId",
                question.ExamId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For QuestionOption tabel 
        private DynamicParameters GenerateQuestionOptionParameters(dynamic questionOption)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Oid",
               questionOption.Id,
               dbType: DbType.Int32,
               direction: ParameterDirection.Input);

            parameters.Add("OContent",
                questionOption.OptionContent,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("OQuestionId",
                questionOption.QuestionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For Result tabel 
        private DynamicParameters GenerateResultParameters(dynamic result)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Rid",
               result.AccountId,
               dbType: DbType.Int32,
               direction: ParameterDirection.Input);

            parameters.Add("RQuestionOptionId",
                result.QuestionOptionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("RAccountId",
                result.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For Course table
        private DynamicParameters GenerateCourseParameters(dynamic course)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("cid",
                course.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("cName",
                course.CourseName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("des",
                course.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                course.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("cImage",
                course.CourseImage,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }
        
        // Dynamic Parameters For Exam table
        private DynamicParameters GenerateExamParameters(dynamic exam)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("exid",
                exam.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("cid",
                exam.CourseId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("exTitle",
                exam.Title,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("passc",
                exam.Passcode,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("des",
                exam.Description,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("exLevel",
                exam.ExamLevel,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("succMark",
                exam.SuccessMark,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("price",
                exam.Cost,
                dbType: DbType.Decimal,
                direction: ParameterDirection.Input);

            parameters.Add("stDate",
                exam.StartDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("enDate",
                exam.EndDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("st",
                exam.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("createDate",
                exam.CreationDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For FillResult table
        private DynamicParameters GenerateFillResultParameters(dynamic fillResult)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("frid",
                fillResult.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("ans",
                fillResult.Answer,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("qid",
                fillResult.QuestionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("accid",
                fillResult.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

    }
}
