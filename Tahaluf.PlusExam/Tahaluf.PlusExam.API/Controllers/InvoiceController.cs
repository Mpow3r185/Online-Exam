using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;
using MailKit.Net.Smtp;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        #region Fields
        private readonly IInvoiceService InvoiceService;
        private readonly IAccountService accountService;
        private readonly IExamService examService;
        private readonly IWebsiteDataService websiteDataService;
        #endregion Fields

        #region Constructor
        public InvoiceController(IInvoiceService _invoiceService, IAccountService _accountService, IExamService _examService, IWebsiteDataService _websiteDataService)
        {
            InvoiceService = _invoiceService;
            accountService = _accountService;
            examService = _examService;
            websiteDataService = _websiteDataService;
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
            SendEmail(invoice.AccountId, invoice.ExamId);
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

        #region SendEmail
        private bool SendEmail(int accid, int? exid)
        {
            Account studentAccount = accountService.GetAccountById(accid);
            Exam exam = examService.GetExamById((int)exid);
            WebsiteData websiteData = websiteDataService.GetWebsiteData();
            int year = DateTime.Now.Year;

            MimeMessage message = new MimeMessage();

            //Email From
            MailboxAddress from = new MailboxAddress("Plus Exam", websiteData.Email);
            message.From.Add(from);

            //Email TO
            MailboxAddress to = new MailboxAddress("Student", studentAccount.Email);
            message.To.Add(to);

            //Email Subject
            message.Subject = $"{exam.Title.ToUpper()} Exam Passcode - PlusExam";

            //Email Body
            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = $"<div style=\"margin: 25px auto; border: 3px solid #016; border-radius: 15px; width: 400px;\">" +
                $"<div style = \"text-align: center; margin: auto; font-family: system-ui, -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif\" > " +
                $"<h5>Hello {studentAccount.Fullname}</h5>" +
                $"<h4>" +
                $"<span>" +
                $"<a style=\"color: #d70926; font-weight: bolder; text-decoration: none;\" href=\"http://localhost:4200/examProfile/{exam.Id}\">{exam.Title.ToUpper()}</a>" +
                $"</span> Exam Passcode" +
                $"</h4>" +
                $"<div style = \"background-color: #016; border-radius: 10px; width: fit-content; height: fit-content; margin: auto;\" > " +
                $"<h5 style=\"color: #fff; font-weight: bolder; padding: 15px 30px; letter-spacing: 3px;\">{exam.Passcode}</h5>" +
                $"</div>" +
                $"<div style=\"margin: 20px auto; font - size: 0.8rem\">" +
                $"<p style=\"font - weight: bold\">" +
                $"Start At:" +
                $"<span style=\"letter - spacing: 1px; margin-left: 5px\">FEB/10/2022 11:58 AM</span>" +
                $"</p>" +
                $"<p style=\"font - weight: bold\">" +
                $"End At:" +
                $"<span style=\"letter - spacing: 1px; margin-left: 5px\">FEB/10/2022 12:58 PM</span>" +
                $"</p>" +
                $"</div>" +
                $"</div>" +
                $"</div>" +
                $"<sub style = \"font-family: Tahoma; font-weight: bold; font-size: 0.6rem; display: block; margin: 30px auto 5px auto; text-align: center;\" > " +
                $"<span style=\"color: #016;\">Plus Exam</span>" +
                $"Copyright &copy; {year}</sub>";

            message.Body = builder.ToMessageBody();

            using (var cliente = new SmtpClient())
            {
                cliente.Connect("smtp-mail.outlook.com", 587, false);
                //liente.Connect("smtp.gmail.com", 465, true);
                cliente.Authenticate(websiteData.Email, websiteData.Password);
                cliente.Send(message);
                cliente.Disconnect(true);
            }
            
            return true;
        }
        #endregion SendEmail
        
        #region invoicesDetails
        [HttpGet]
        [Route("invoicesDetails")]
        public List<InvoiceDetailsDTO> invoicesDetails()
        {
            return InvoiceService.invoicesDetails();
        }
        #endregion invoicesDetails

    }
}
