using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;

namespace Tahaluf.PlusExam.Core.RepositoryInterface
{
    public interface IWebsiteDataRepository
    {
        bool UpdateWebsiteData(WebsiteData websiteData);
        WebsiteData GetWebsiteData();

    }
}
