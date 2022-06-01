using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IHomePageRepository
    {
        // Get Accounts
        List<HomePage> GetHomePage();

        // Update HomePage
        bool UpdateHomePage(HomePage homePage);
    }
}
