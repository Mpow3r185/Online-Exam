using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("[controller]")]
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
        [HttpGet]
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

    }
}
