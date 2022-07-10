using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteDataController : ControllerBase
    {
        private readonly IWebsiteDataService websiteDataService;

        public WebsiteDataController(IWebsiteDataService _websiteDataService)
        {
            websiteDataService = _websiteDataService;
        }

        [HttpPut]
        public bool UpdateWebsiteData(WebsiteData websiteData)
        {
            return websiteDataService.UpdateWebsiteData(websiteData);
        }

        [HttpGet]
        public WebsiteData GetWebsiteData()
        {
            return websiteDataService.GetWebsiteData();
        }
    }
}
