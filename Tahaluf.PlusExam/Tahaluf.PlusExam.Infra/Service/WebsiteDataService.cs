using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class WebsiteDataService : IWebsiteDataService
    {
        private readonly IWebsiteDataRepository websiteDataRepository;

        public WebsiteDataService(IWebsiteDataRepository _websiteDataRepository)
        {
            websiteDataRepository = _websiteDataRepository;
        }

        public bool UpdateWebsiteData(WebsiteData websiteData)
        {
            return websiteDataRepository.UpdateWebsiteData(websiteData);
        }

        public WebsiteData GetWebsiteData()
        {
            return websiteDataRepository.GetWebsiteData();
        }
    }
}
