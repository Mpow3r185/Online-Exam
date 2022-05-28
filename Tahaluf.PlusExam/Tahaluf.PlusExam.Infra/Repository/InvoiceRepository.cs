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
        private readonly IDbContext dbContext;

        public InvoiceRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<Invoice> GetInvoices()
        {
            IEnumerable<Invoice> result = dbContext.Connection.Query<Invoice>("InvoicePackage.GetInvoices", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateInvoice(Invoice invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("createDate", invoice.CreatioDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("exam_id", invoice.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("acc_id", invoice.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("InvoicePackage.CreateInvoice", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateInvoice(Invoice invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("invoiceID", invoice.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("createDate", invoice.CreatioDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add("exam_id", invoice.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("acc_id", invoice.AccountId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("InvoicePackage.UpdateInvoice", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteInvoice(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("invoiceID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("InvoicePackage.DeleteInvoice", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

       

       
    }
}
