using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.ServiceInterface
{
    public interface IWebsiteDataService
    {
        bool UpdateWebsiteData(WebsiteData websiteData);
        WebsiteData GetWebsiteData();

    }
}
