using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IHomePageService
    {
        //Get Home Page Info
        List<HomePage> GetHomePage();

        // Update HomePage
        bool UpdateHomePage(HomePage homePage);
    }
}
