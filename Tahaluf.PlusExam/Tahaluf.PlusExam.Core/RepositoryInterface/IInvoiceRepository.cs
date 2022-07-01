using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IInvoiceRepository
    {
        // Get Invoices
        List<Invoice> GetInvoices();

        // Create Invoice
        bool CreateInvoice(Invoice invoice);

        // Update Invoice
        bool UpdateInvoice(Invoice invoice);

        // Delete Invoice
        bool DeleteInvoice(int id);
        
        //Financial Matters
        List<FinancialDTO> FinancialMatters();
        
        //Get Invice By User Id
        List<InvoiceDTO> getInvoiceByUserId(int id);
    }
}
