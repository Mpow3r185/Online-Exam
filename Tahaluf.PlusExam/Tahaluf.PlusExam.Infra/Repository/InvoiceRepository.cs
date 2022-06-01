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
    public class InvoiceRepository: IInvoiceRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public InvoiceRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetInvoices
        public List<Invoice> GetInvoices()
        {
            return dbContext.Connection.Query<Invoice>(
                "InvoicePackage.GetInvoices", 
                commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion GetInvoices

        #region CreateInvoice
        public bool CreateInvoice(Invoice invoice)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("createDate", 
                invoice.CreatioDate, 
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

            dbContext.Connection.ExecuteAsync(
                "InvoicePackage.CreateInvoice", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion CreateInvoice

        #region UpdateInvoice
        public bool UpdateInvoice(Invoice invoice)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("invoiceID", 
                invoice.Id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            parameters.Add("createDate", 
                invoice.CreatioDate, 
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

            dbContext.Connection.ExecuteAsync(
                "InvoicePackage.UpdateInvoice", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion UpdateInvoice

        #region DeleteInvoice
        public bool DeleteInvoice(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("invoiceID", 
                id, 
                dbType: DbType.Int32, 
                direction: ParameterDirection.Input);

            dbContext.Connection.ExecuteAsync(
                "InvoicePackage.DeleteInvoice", parameters, 
                commandType: CommandType.StoredProcedure);

            return true;
        }
        #endregion DeleteInvoice

        #endregion CRUD_Operation
        
         #region FinancialMatters
        public List<FinancialDTO> FinancialMatters()
        {
            IEnumerable<FinancialDTO> result = dbContext.Connection.Query<FinancialDTO>("InvoicePackage.ObtainsFinancial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        #endregion FinancialMatters
        
    }
}
