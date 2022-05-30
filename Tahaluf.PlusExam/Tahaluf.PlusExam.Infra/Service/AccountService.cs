using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class AccountService : IAccountService
    {
        #region Fields
        private readonly IAccountRepository accountRepository;
        #endregion Fields

        #region Constructor
        public AccountService(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }
        #endregion Constructor

        #region CRUD_Operation

        #region CreateAccount
        public bool CreateAccount(Account account)
        {
            return accountRepository.CreateAccount(account);
        }
        #endregion CreateAccount

        #region DeleteAccount
        public bool DeleteAccount(int accid)
        {
            return accountRepository.DeleteAccount(accid);
        }
        #endregion DeleteAccount

        #region GetAccounts
        public List<Account> GetAccounts()
        {
            return accountRepository.GetAccounts();
        }
        #endregion GetAccounts

        #region UpdateAccount
        public bool UpdateAccount(Account account)
        {
            return accountRepository.UpdateAccount(account);
        }
        #endregion UpdateAccount

        #endregion CRUD_Operation

        public bool BlockUser(UniqueAccountData uniqueAccountData)
        {
            return accountRepository.BlockUser(uniqueAccountData);
        }

        public List<Account> GetBlockAccounts()
        {
            return accountRepository.GetBlockAccounts();
        }

        public List<string> GetBlockedUsernames()
        {
            return accountRepository.GetBlockedUsernames();
        }

        public List<string> GetEmails()
        {
            return accountRepository.GetEmails();
        }

        public List<string> GetFullNames()
        {
            return accountRepository.GetFullNames();
        }

        public List<string> GetUsernames()
        {
            return accountRepository.GetUsernames();
        }

        public List<Account> SearchAccount(AccountFilter accountFilter)
        {
            return accountRepository.SearchAccount(accountFilter);
        }

        public bool UnblockUser(UniqueAccountData uniqueAccountData)
        {
            return accountRepository.UnblockUser(uniqueAccountData);
        }
        
        public string UserLogin(UserInfoDTO userInfoDTO)
        {
            var LoginResult = accountRepository.UserLogin(userInfoDTO);

            if (LoginResult != null)
            {
                var TokenHandler = new JwtSecurityTokenHandler();
                var TokenKey = Encoding.ASCII.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING ,JWT SECRET KEY IN SIGNATURE");

                var TokenDes = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,LoginResult.Username),
                        new Claim(ClaimTypes.Role,LoginResult.Rolename)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = TokenHandler.CreateToken(TokenDes);
                return TokenHandler.WriteToken(token);
            }
            else
            {
                return null;
            }
        }
    }
}
