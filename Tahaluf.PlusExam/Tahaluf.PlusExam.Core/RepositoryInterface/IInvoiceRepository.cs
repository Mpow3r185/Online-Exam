using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetInvoices();
        bool CreateInvoice(Invoice invoice);
        bool UpdateInvoice(Invoice invoice);
        bool DeleteInvoice(int id);
    }
}
