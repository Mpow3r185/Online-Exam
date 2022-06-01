using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.Infra.Service
{
    public class HomePageService : IHomePageService
    {
        #region Fields
        private readonly IHomePageRepository homePageRepository;
        #endregion Fields

        #region Constructor
        public HomePageService(IHomePageRepository _homePageRepository)
        {
            homePageRepository = _homePageRepository;
        }
        #endregion Constructor

        #region CRUD_HomePage

        public List<HomePage> GetHomePage()
        {
            return homePageRepository.GetHomePage();
        }

        public bool UpdateHomePage(HomePage homePage)
        {
            return homePageRepository.UpdateHomePage(homePage);
        }

        #endregion CRUD_HomePage
    }
}
