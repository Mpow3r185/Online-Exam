using Microsoft.AspNetCore.Http;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using System;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields
        private readonly IAccountService accountService;
        #endregion Fields

        #region Constructor
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateAccount
        [HttpPost]
        public bool CreateAccount(Account account)
        {
            return accountService.CreateAccount(account);
        }
        #endregion CreateAccount

        #region DeleteAccount
        [HttpDelete]
        [Route("deleteAccount/{accid}")]
        public bool DeleteAccount(int accid)
        {
            return accountService.DeleteAccount(accid);
        }
        #endregion DeleteAccount

        #region GetAccounts
        [HttpGet]
        public List<Account> GetAccounts()
        {
            return accountService.GetAccounts();
        }
        #endregion GetAccounts

        #region UpdateAccount
        [HttpPut]
        public bool UpdateAccount(Account account)
        {
            return accountService.UpdateAccount(account);
        }
        #endregion UpdateAccount

        #endregion CRUD_Operation

        #region SearchAccount
        [HttpPost]
        [Route("SearchAccount")]
        public List<Account> SearchAccount(AccountFilter accountFilter)
        {
            return accountService.SearchAccount(accountFilter);
        }
        #endregion SearchAccount

        #region GetUsernames
        [HttpGet]
        [Route("GetUsernames")]
        public List<string> GetUsernames()
        {
            return accountService.GetUsernames();
        }
        #endregion GetUsernames

        #region GetFullnames
        [HttpGet]
        [Route("GetFullnames")]
        public List<string> GetFullNames()
        {
            return accountService.GetFullNames();
        }
        #endregion GetFullnames

        #region GetEmails
        [HttpGet]
        [Route("GetEmails")]
        public List<string> GetEmails()
        {
            return accountService.GetEmails();
        }
        #endregion GetEmails

        #region GetBlockAccounts
        [HttpGet]
        [Route("GetBlockAccounts")]
        public List<Account> GetBlockAccounts()
        {
            return accountService.GetBlockAccounts();
        }
        #endregion GetBlockAccounts

        #region GetBlockedUsernames
        [HttpGet]
        [Route("GetBlockedUsernames")]
        public List<string> GetBlockedUsernames()
        {
            return accountService.GetBlockedUsernames();
        }
        #endregion GetBlockedUsernames

        #region BlockUser
        [HttpPut]
        [Route("BlockUser")]
        public bool BlockUser(UniqueAccountData uniqueAccountData)
        {
            return accountService.BlockUser(uniqueAccountData);
        }
        #endregion BlockUser

        #region UnblockUser
        [HttpPut]
        [Route("UnblockUser")]
        public bool UnblockUser(UniqueAccountData uniqueAccountData)
        {
            return accountService.UnblockUser(uniqueAccountData);
        }
        #endregion UnblockUser

        #region UserLogin
        [HttpPost]
        [Route("login")]
        public IActionResult UserLogin(UserInfoDTO userInfoDTO)
        {
            var token = accountService.UserLogin(userInfoDTO);
            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return Unauthorized("Username or Password is incorrect");
            }
        }

        #endregion UserLogin

        #region UploadImage
        [HttpPost]
        [Route("Upload")]
        public Account UploadImage()
        {
            try
            {
                var image = Request.Form.Files[0];
                var imageName = Guid.NewGuid() + "_" + image.FileName;
                var fullPath = Path.Combine("Image", imageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                Account account = new Account();
                account.ProfilePicture = imageName;
                return account;
            }

            catch (Exception)
            {
                return null;
            }
        }
        #endregion UploadImage

        #region GetAccountById
        [HttpPost]
        [Route("GetAccountById/{accid}")]
        public Account GetAccountById(int accid)
        {
            return accountService.GetAccountById(accid);
        }
        #endregion GetAccountById
        
        #region SendEmail
        [HttpPost]
        [Route("SendEmail")]
        public bool SendEmail(EmailDTO emailDTO)
        {
            Account account = accountService.GetAccountById(emailDTO.studentId);

            MimeMessage message = new MimeMessage();

            //Email From
            //dabdalhammed@hotmail.com
            //pass: ro02-9Us7L@u2i_eFOSO
            MailboxAddress from = new MailboxAddress("Tahaluf PlusExam", emailDTO.SendFrom);
            message.From.Add(from);

            //Email TO
            MailboxAddress to = new MailboxAddress("Student", account.Email);
            message.To.Add(to);

            //Email Subject
            message.Subject = "Exam Password";

            //Email Body
            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = $"<h1>Hello {account.Fullname}<h1>,<br>" +
                $"<h3>Greeting from Tahaluf PlusExam Center!!<h3><br>" +
                $"We thank you for buying the exam,<br>" +
                $"The Exam Password: {emailDTO.examPassword}<br>" +
                $"Please don't share this password with anyone.<br>" +
                $"With regards Tahaluf PlusExam.";
            message.Body = builder.ToMessageBody();

            using (var cliente = new SmtpClient())
            {
                cliente.Connect("smtp-mail.outlook.com", 587, false);
                //liente.Connect("smtp.gmail.com", 465, true);
                cliente.Authenticate(emailDTO.SendFrom, emailDTO.emailPassword);
                cliente.Send(message);
                cliente.Disconnect(true);
            }

            return true;
        }
        #endregion SendEmail
        

    }
}
