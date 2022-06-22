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
                // Certificate Table
                case "Certificate":
                    {
                        DynamicParameters certificateDynamicParameters = GenerateCertificateParameters(entity);
                        certificateDynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CertificatePackage.CertificateCRUD", certificateDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // CreditCard Table
                case "CreditCard":
                    {
                        DynamicParameters creditCardDynamicParameters = GenerateCreditCardParameters(entity);
                        creditCardDynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CreditCardPackage.CreditCardCRUD", creditCardDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Invoice Table
                case "Invoice":
                    {
                        DynamicParameters invoiceDynamicParameters = GenerateInvoiceParameters(entity);
                        invoiceDynamicParameters.Add("func",
                            "CREATE",
                            dbType: DbType.String,
                            direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "InvoicePackage.InvoiceCRUD", invoiceDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Phone Number Table
                case "PhoneNumber":
                    {
                        DynamicParameters phoneNumberDynamicParameters = GeneratePhoneNumberParameters(entity);
                        phoneNumberDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "PhoneNumberPackage.PhoneNumberCRUD", phoneNumberDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Score Table
                case "Score":
                    {
                        DynamicParameters scoreDynamicParameters = GenerateScoreParameters(entity);
                        scoreDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "ScorePackage.ScoreCRUD", scoreDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Correct Answer Table
                case "CorrectAnswer":
                    {
                        DynamicParameters correctAnswerDynamicParameters = GenerateCorrectAnswerParameters(entity);
                        correctAnswerDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CorrectAnswerPackage.CorrectAnswerCRUD", correctAnswerDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                     // Testimonial Table
                case "Testimonial":
                    {
                        DynamicParameters testimonialDynamicParameters = GenerateTestimonialParameters(entity);
                        testimonialDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "TestimonialPackage.TestimonialCRD", testimonialDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                 // Our Service Table
                case "OurService":
                    {
                        DynamicParameters serviceDynamicParameters = GenerateOurServiceParameters(entity);
                        serviceDynamicParameters.Add("func",
                                "CREATE",
                                dbType: DbType.String,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "OurServicePackage.OurServiceCRUD", serviceDynamicParameters,
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
                // Certificate Table
                case "Certificate":
                    {
                        DynamicParameters certificateDynamicParameters = new DynamicParameters();
                        certificateDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        certificateDynamicParameters.Add("CertificateID",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CertificatePackage.CertificateCRUD",
                            certificateDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // CreditCard Table
                case "CreditCard":
                    {
                        DynamicParameters creditCardDynamicParameters = new DynamicParameters();
                        creditCardDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        creditCardDynamicParameters.Add("card_id",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CreditCardPackage.CreditCardCRUD",
                            creditCardDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Invoice Table
                case "Invoice":
                    {
                        DynamicParameters invoiceDynamicParameters = new DynamicParameters();
                        invoiceDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        invoiceDynamicParameters.Add("invoiceID",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "InvoicePackage.InvoiceCRUD",
                            invoiceDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Phone Number Table
                case "PhoneNumber":
                    {
                        DynamicParameters phoneNumberDynamicParameters = new DynamicParameters();
                        phoneNumberDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        phoneNumberDynamicParameters.Add("PHNUMID",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "PhoneNumberPackage.PhoneNumberCRUD",
                            phoneNumberDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Score Table
                case "Score":
                    {
                        DynamicParameters scoreDynamicParameters = new DynamicParameters();
                        scoreDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        scoreDynamicParameters.Add("SCOREID",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "ScorePackage.ScoreCRUD",
                            scoreDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Correct Answer Table
                case "CorrectAnswer":
                    {
                        DynamicParameters correctAnswerDynamicParameters = new DynamicParameters();
                        correctAnswerDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        correctAnswerDynamicParameters.Add("CANSWERID",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "CorrectAnswerPackage.CorrectAnswerCRUD",
                            correctAnswerDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                     // Testimonial Table
                case "Testimonial":
                    {
                        DynamicParameters testimonialDynamicParameters = new DynamicParameters();
                        testimonialDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        testimonialDynamicParameters.Add("tstId",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "TestimonialPackage.TestimonialCRD",
                            testimonialDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                 // Service Table
                case "OurService":
                    {
                        DynamicParameters serviceDynamicParameters = new DynamicParameters();
                        serviceDynamicParameters.Add("func",
                                "DELETE",
                                dbType: DbType.String);

                        serviceDynamicParameters.Add("Sid",
                                id,
                                dbType: DbType.Int32,
                                direction: ParameterDirection.Input);

                        dbContext.Connection.ExecuteAsync(
                            "OurServicePackage.OurServiceCRUD", serviceDynamicParameters,
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
                // Certificate Table
                case "Certificate":
                    {
                        return dbContext.Connection.Query<Certificate>(
                            "CertificatePackage.CertificateCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
                // CreditCard Table
                case "CreditCard":
                    {
                        return dbContext.Connection.Query<CreditCard>(
                            "CreditCardPackage.CreditCardCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
                // Invoice Table
                case "Invoice":
                    {
                        return dbContext.Connection.Query<Invoice>(
                            "InvoicePackage.InvoiceCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
                // Phone Number Table
                case "PhoneNumber":
                    {
                        return dbContext.Connection.Query<PhoneNumber>(
                            "PhoneNumberPackage.PhoneNumberCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
                // Score Table
                case "Score":
                    {
                        return dbContext.Connection.Query<Score>(
                            "ScorePackage.ScoreCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
                // Correct Answer Table
                case "CorrectAnswer":
                    {
                        return dbContext.Connection.Query<CorrectAnswer>(
                            "CorrectAnswerPackage.CorrectAnswerCRUD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
                     // Testimonial Table
                case "Testimonial":
                    {
                        return dbContext.Connection.Query<Testimonial>(
                            "TestimonialPackage.TestimonialCRD",
                            commandType: CommandType.StoredProcedure).ToList();
                    }
                    
                    // Our Service Table
                case "OurService":
                    {
                        return dbContext.Connection.Query<OurService>(
                       "OurServicePackage.OurServiceCRUD",
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
                        DynamicParameters examDynamicParameters = GenerateExamParameters(entity);
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
                        DynamicParameters fillResultDynamicParameters = GenerateFillResultParameters(entity);
                        fillResultDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "FillResultPackage.FillResultCRUD", fillResultDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Certificate Table
                case "Certificate":
                    {
                        DynamicParameters certificateDynamicParameters = GenerateCertificateParameters(entity);
                        certificateDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "CertificatePackage.CertificateCRUD", certificateDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // CreditCard Table
                case "CreditCard":
                    {
                        DynamicParameters creditCardDynamicParameters = GenerateCreditCardParameters(entity);
                        creditCardDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "CreditCardPackage.CreditCardCRUD", creditCardDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Invoice Table
                case "Invoice":
                    {
                        DynamicParameters invoiceDynamicParameters = GenerateInvoiceParameters(entity);
                        invoiceDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "InvoicePackage.InvoiceCRUD", invoiceDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Phone Number Table
                case "PhoneNumber":
                    {
                        DynamicParameters phoneNumberDynamicParameters = GeneratePhoneNumberParameters(entity);
                        phoneNumberDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "PhoneNumberPackage.PhoneNumberCRUD", phoneNumberDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Score Table
                case "Score":
                    {
                        DynamicParameters scoreDynamicParameters = GenerateScoreParameters(entity);
                        scoreDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "ScorePackage.ScoreCRUD", scoreDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                // Correct Answer Table
                case "CorrectAnswer":
                    {
                        DynamicParameters correctAnswerDynamicParameters = GenerateCorrectAnswerParameters(entity);
                        correctAnswerDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "CorrectAnswerPackage.CorrectAnswerCRUD", correctAnswerDynamicParameters,
                            commandType: CommandType.StoredProcedure);

                        return true;
                    }
                    
                // our Service Table
                case "OurService":
                    {
                        DynamicParameters ourserviceDynamicParameters = GenerateOurServiceParameters(entity);
                        ourserviceDynamicParameters.Add("func",
                            "UPDATE",
                            dbType: DbType.String);

                        dbContext.Connection.ExecuteAsync(
                            "OurServicePackage.OurServiceCRUD", ourserviceDynamicParameters,
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

        // Dynamic Parameters For Certificate table
        private DynamicParameters GenerateCertificateParameters(dynamic certificate)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CertificateID",
                certificate.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("createDate",
                    certificate.CreatioDate,
                    dbType: DbType.DateTime,
                    direction: ParameterDirection.Input);

            parameters.Add("exam_id",
                certificate.ExamId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("acc_id",
                certificate.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For Certificate table
        private DynamicParameters GenerateCreditCardParameters(dynamic creditCard)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("card_id",
                creditCard.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("card_number",
                creditCard.CardNumber,
                dbType: DbType.Int64,
                direction: ParameterDirection.Input);

            parameters.Add("amount",
                creditCard.Balance,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("acc_id",
                creditCard.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For Invoice table
        private DynamicParameters GenerateInvoiceParameters(dynamic invoice)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("invoiceID",
                invoice.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("createDate",
                invoice.CreationDate,
                dbType: DbType.DateTime,
                direction: ParameterDirection.Input);

            parameters.Add("exam_id",
                invoice.ExamId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("acc_id",
                invoice.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }


        // Dynamic Parameters For Phone Number tabel 
        private DynamicParameters GeneratePhoneNumberParameters(dynamic phoneNumber)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("PHNUMID",
                phoneNumber.Id,
                DbType.Int32,
                direction: ParameterDirection.Input);
            parameters.Add("PHNUM",
                phoneNumber.PhoneNum,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("ACCID",
                phoneNumber.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For Score tabel 
        private DynamicParameters GenerateScoreParameters(dynamic score)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SCOREID",
                score.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("SCGRADE",
                score.Grade,
                dbType: DbType.Double,
                direction: ParameterDirection.Input);

            parameters.Add("SCSTATUS",
                score.Status, dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("EXID",
                score.ExamId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("ACCID",
                score.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }

        // Dynamic Parameters For Correct Answer tabel 
        private DynamicParameters GenerateCorrectAnswerParameters(dynamic correctAnswer)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("CANSWERID",
                correctAnswer.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("QOID",
                correctAnswer.QuestionOptionId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }
        // Dynamic Parameters For Testimonial tabel 
        private DynamicParameters GenerateTestimonialParameters(dynamic testimonial)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("tstId",
                testimonial.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("accid",
                testimonial.AccountId,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("msg",
                testimonial.Message,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("stat",
                testimonial.Status,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }
        
        // Dynamic Parameters For Our Service tabel 
        private DynamicParameters GenerateOurServiceParameters(dynamic service)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Sid",
                service.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("Stitle",
                service.Title,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("Stext",
                service.Text,
                dbType: DbType.String,
                direction: ParameterDirection.Input);
            #endregion DynamicParameters

            return parameters;
        }
    }
}
