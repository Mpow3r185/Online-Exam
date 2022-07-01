using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class InvoiceService : IInvoiceService
    {
        #region Fields
        private readonly IInvoiceRepository invoiceRepository;
        #endregion Fields

        #region Constructor
        public InvoiceService(IInvoiceRepository _invoiceRepository)
        {
            invoiceRepository = _invoiceRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetInvoices
        public List<Invoice> GetInvoices()
        {
            return invoiceRepository.GetInvoices();
        }
        #endregion GetInvoices

        #region CreateInvoice
        public bool CreateInvoice(Invoice invoice)
        {
            return invoiceRepository.CreateInvoice(invoice);
        }
        #endregion CreateInvoice

        #region UpdateInvoice
        public bool UpdateInvoice(Invoice invoice)
        {
            return invoiceRepository.UpdateInvoice(invoice);
        }
        #endregion UpdateInvoice

        #region DeleteInvoice
        public bool DeleteInvoice(int id)
        {
            return invoiceRepository.DeleteInvoice(id);
        }
        #endregion DeleteInvoice

        #endregion CRUD_Operation
        
        #region Financial_Matters
        public List<FinancialDTO> FinancialMatters()
        {
            return invoiceRepository.FinancialMatters();
        }
        #endregion Financial_Matters
        
         #region getInvoiceByUserId
        public List<InvoiceDTO> getInvoiceByUserId(int id)
        {
            return invoiceRepository.getInvoiceByUserId(id);
        }
        #endregion getInvoiceByUserId
        
    }
}
