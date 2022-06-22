using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.ServiceInterface;

namespace Tahaluf.PlusExam.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DynamicHomeController : ControllerBase
        {
            #region Fields
            private readonly IDynamicHomeService dynamicHomeService;
            #endregion Fields

            #region Constructor
            public DynamicHomeController(IDynamicHomeService _IdynamicHomeService)
            {
                dynamicHomeService = _IdynamicHomeService;
            }
            #endregion Constructor

            #region CRUD_HomePage

            [HttpGet]
            public List<DynamicHome> GetHomePage()
            {
                return dynamicHomeService.GetAll();
            }

            [HttpPut]
            public bool UpdateHomePage(DynamicHome dynamicHome)
            {
                return dynamicHomeService.UpdateHome(dynamicHome);
            }

            #endregion CRUD_HomePage
        }
    }
