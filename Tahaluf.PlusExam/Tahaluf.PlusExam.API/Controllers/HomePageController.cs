using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        #region Fields
        private readonly IHomePageService homePageService;
        #endregion Fields

        #region Constructor
        public HomePageController(IHomePageService _homePageService)
        {
            homePageService = _homePageService;
        }
        #endregion Constructor

        #region CRUD_HomePage

        [HttpGet]
        public List<HomePage> GetHomePage()
        {
            return homePageService.GetHomePage();
        }

        [HttpPut]
        public bool UpdateHomePage(HomePage homePage)
        {
            return homePageService.UpdateHomePage(homePage);
        }

        #endregion CRUD_HomePage
    }
}
