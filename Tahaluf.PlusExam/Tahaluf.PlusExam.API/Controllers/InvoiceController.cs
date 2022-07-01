using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        #region Fields
        private readonly IInvoiceService InvoiceService;
        #endregion Fields

        #region Constructor
        public InvoiceController(IInvoiceService _invoiceService)
        {
            InvoiceService = _invoiceService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region GetInvoices
        [HttpGet]
        public List<Invoice> GetInvoices()
        {
            return InvoiceService.GetInvoices();
        }
        #endregion GetInvoices

        #region CreateInvoice
        [HttpPost]
        public bool CreateInvoice(Invoice invoice)
        {
            return InvoiceService.CreateInvoice(invoice);
        }
        #endregion CreateInvoice

        #region UpdateInvoice
        [HttpPut]
        public bool UpdateInvoice(Invoice invoice)
        {
            return InvoiceService.UpdateInvoice(invoice);
        }
        #endregion UpdateInvoice

        #region DeleteInvoice
        [HttpDelete]
        [Route("DeleteInvoice/{id}")]
        public bool DeleteInvoice(int id)
        {
            return InvoiceService.DeleteInvoice(id);
        }
        #endregion DeleteInvoice

        #endregion CRUD_Operation
        
        #region Financial_Matters
        [HttpGet]
        [Route("FinancialMatters")]
        public List<FinancialDTO> FinancialMatters()
        {
            return InvoiceService.FinancialMatters();
        }
        #endregion Financial_Matters
        
        #region getInvoiceByUserId
        [HttpGet]
        [Route("GetInvoiceByUserId/{id}")]
        public List<InvoiceDTO> getInvoiceByUserId(int id)
        {
            return InvoiceService.getInvoiceByUserId(id);
        }
        #endregion getInvoiceByUserId
        
    }
}
