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
    public class InvoiceRepository: IInvoiceRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        private readonly IGenericCRUD<Invoice> genericCRUD;
        #endregion Fields

        #region Constructor
        public InvoiceRepository(IDbContext _dbContext)
        {
            genericCRUD = new GenericCRUD<Invoice>(_dbContext);
            dbContext = _dbContext;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetInvoices
        public List<Invoice> GetInvoices()
        {
            return genericCRUD.GetAll();
        }
        #endregion GetInvoices

        #region CreateInvoice
        public bool CreateInvoice(Invoice invoice)
        {
            return genericCRUD.Create(invoice);
        }
        #endregion CreateInvoice

        #region UpdateInvoice
        public bool UpdateInvoice(Invoice invoice)
        {
            return genericCRUD.Update(invoice);
        }
        #endregion UpdateInvoice

        #region DeleteInvoice
        public bool DeleteInvoice(int id)
        {
            return genericCRUD.Delete(id);
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
