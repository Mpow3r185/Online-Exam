using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        public InvoiceService(IInvoiceRepository _invoiceRepository)
        {
            invoiceRepository = _invoiceRepository;
        }
        public List<Invoice> GetInvoices()
        {
            return invoiceRepository.GetInvoices();
        }

        public bool CreateInvoice(Invoice invoice)
        {
            return invoiceRepository.CreateInvoice(invoice);
        }
        public bool UpdateInvoice(Invoice invoice)
        {
            return invoiceRepository.UpdateInvoice(invoice);
        }

        public bool DeleteInvoice(int id)
        {
            return invoiceRepository.DeleteInvoice(id);
        }

        

       
    }
}
