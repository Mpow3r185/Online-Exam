using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.DTO;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IAccountRepository
    {
        // Get Accounts
        List<Account> GetAccounts();


        // Create Account
        bool CreateAccount(Account account);


        // Update Account
        bool UpdateAccount(Account account);


        // Delete Account
        bool DeleteAccount(int accid);


        // Get Usernames
        List<string> GetUsernames();


        // Get Full Names
        List<string> GetFullNames();


        // Get Emails
        List<string> GetEmails();


        // Search Account
        List<Account> SearchAccount(AccountFilter accountFilter);


        // Get Block Accounts
        List<Account> GetBlockAccounts();


        // Get Blocked Usernames
        List<string> GetBlockedUsernames();


        // Block User
        bool BlockUser(UniqueAccountData uniqueAccountData);


        // Unblock User
        bool UnblockUser(UniqueAccountData uniqueAccountData);
    }
}
