using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService InvoiceService;

        public InvoiceController(IInvoiceService _invoiceService)
        {
            InvoiceService = _invoiceService;
        }
        [HttpGet]
        public List<Invoice> GetInvoices()
        {
            return InvoiceService.GetInvoices();
        }
        [HttpPost]
        public bool CreateInvoice(Invoice invoice)
        {
            return InvoiceService.CreateInvoice(invoice);
        }
        [HttpPut]
        public bool UpdateInvoice(Invoice invoice)
        {
            return InvoiceService.UpdateInvoice(invoice);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteInvoice(int id)
        {
            return InvoiceService.DeleteInvoice(id);
        }
    }
}
