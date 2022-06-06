using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
                case "Account":
                    {
                        DynamicParameters dynamicParameters = GenerateAccountParameters(entity);
                        dynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "AccountPackage.AccountCRUD", dynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;

                    }

                // Question Table
                case "Question":
                    {
                        DynamicParameters QuestiondynamicParameters = GenerateQuestionParameters(entity);
                        QuestiondynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionPackage.QuestionCRUD", QuestiondynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;
                        
                    }

                // QuestionOption Table
                case "QuestionOption":
                    {
                        DynamicParameters QuestionOptiondynamicParameters = GenerateQuestionOptionParameters(entity);
                        QuestionOptiondynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionOptionPackage.QuestionOptionCRUD", QuestionOptiondynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;

                    }

                // Result Table
                case "Result":
                    {
                        DynamicParameters ResultdynamicParameters = GenerateResultParameters(entity);
                        ResultdynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "ResultPackage.ResultCRUD", ResultdynamicParameters,
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
                // Question Table
                case "Question":
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("func",
                            "DELETE",
                            dbType: DbType.String);
                        parameters.Add("Qid",
                            id,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionPackage.QuestionCRUD", parameters,
                            commandType: CommandType.StoredProcedure);
                        return true;

                    }

                // QuestionOption Table
                case "QuestionOption":
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("func",
                            "DELETE",
                            dbType: DbType.String);
                        parameters.Add("Oid",
                          id,
                          dbType: DbType.Int32,
                          direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionOptionPackage.QuestionOptionCRUD", parameters,
                            commandType: CommandType.StoredProcedure);
                        return true;

                    }

                // Result Table
                case "Result":
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("func",
                            "DELETE",
                            dbType: DbType.String);
                        parameters.Add("Rid",
                            id,
                            dbType: DbType.Int32,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "ResultPackage.ResultCRUD", parameters,
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
            }

            return null;
        }

        public bool Update(T entity)
        {
            switch (type)
            {
                // Question Table
                case "Question":
                    {
                        DynamicParameters QuestiondynamicParameters = GenerateQuestionParameters(entity);
                        QuestiondynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionPackage.QuestionCRUD", QuestiondynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;

                    }

                // QuestionOption Table
                case "QuestionOption":
                    {
                        DynamicParameters QuestionOptiondynamicParameters = GenerateQuestionOptionParameters(entity);
                        QuestionOptiondynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "QuestionOptionPackage.QuestionOptionCRUD", QuestionOptiondynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;

                    }

                // Result Table
                case "Result":
                    {
                        DynamicParameters ResultdynamicParameters = GenerateResultParameters(entity);
                        ResultdynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "ResultPackage.ResultCRUD", ResultdynamicParameters,
                            commandType: CommandType.StoredProcedure);
                        return true;

                    }


            }
            return true;
        }

        //Dynamic Parameters For Account tabel 
        private DynamicParameters GenerateAccountParameters(dynamic account)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
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
        
        //Dynamic Parameters For Question tabel 
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

        //Dynamic Parameters For QuestionOption tabel 
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

        //Dynamic Parameters For Result tabel 
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
        
    }
}
