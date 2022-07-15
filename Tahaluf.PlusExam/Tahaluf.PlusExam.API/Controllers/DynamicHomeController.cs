using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
            
            #region UploadImage
        [HttpPost]
        [Route("Upload")]
        public DynamicHome UploadImage()
        {
            try
            {
                string dynamicPath = "C:\\Users\\Mahmoud Hamarsheh\\Desktop\\PE\\Online-Exam\\Angular P\\src\\assets\\images\\siteImage";

                DynamicHome dynamicHome = new DynamicHome();
                var image1 = Request.Form.Files[0];
                var imageName1 = Guid.NewGuid() + "_" + image1.FileName;
                var fullPath1 = Path.Combine(dynamicPath, imageName1);
                using (var stream = new FileStream(fullPath1, FileMode.Create))
                {
                    image1.CopyTo(stream);
                }

                dynamicHome.logoDark = imageName1;

                var image2 = Request.Form.Files[1];
                var imageName2 = Guid.NewGuid() + "_" + image2.FileName;
                var fullPath2 = Path.Combine(dynamicPath, imageName2);
                using (var stream = new FileStream(fullPath2, FileMode.Create))
                {
                    image2.CopyTo(stream);
                }

                dynamicHome.logoLight = imageName2;

                //var image3 = Request.Form.Files[2];
                //var imageName3 = Guid.NewGuid() + "_" + image3.FileName;
                //var fullPath3 = Path.Combine(dynamicPath, imageName3);
                //using (var stream = new FileStream(fullPath3, FileMode.Create))
                //{
                //    image3.CopyTo(stream);
                //}
                //dynamicHome.imgSlider1 = imageName3;

                //var image4 = Request.Form.Files[3];
                //var imageName4 = Guid.NewGuid() + "_" + image4.FileName;
                //var fullPath4 = Path.Combine(dynamicPath, imageName4);
                //using (var stream = new FileStream(fullPath4, FileMode.Create))
                //{
                //    image4.CopyTo(stream);
                //}
                //dynamicHome.imgSlider2 = imageName4;

                //var image5 = Request.Form.Files[4];
                //var imageName5 = Guid.NewGuid() + "_" + image5.FileName;
                //var fullPath5 = Path.Combine(dynamicPath, imageName5);
                //using (var stream = new FileStream(fullPath5, FileMode.Create))
                //{
                //    image5.CopyTo(stream);
                //}
                //dynamicHome.imgSlider3 = imageName5;

                //var image6 = Request.Form.Files[5];
                //var imageName6 = Guid.NewGuid() + "_" + image6.FileName;
                //var fullPath6 = Path.Combine("C:\\Users\\Mahmoud Hamarsheh\\Desktop\\PE\\Online-Exam\\Angular P\\src\\assets\\images\\siteImage", imageName6);
                //using (var stream = new FileStream(fullPath6, FileMode.Create))
                //{
                //    image6.CopyTo(stream);
                //}
                //dynamicHome.footerBackground = imageName6;

                //var image7 = Request.Form.Files[6];
                //var imageName7 = Guid.NewGuid() + "_" + image7.FileName;
                //var fullPath7 = Path.Combine(dynamicPath, imageName7);
                //using (var stream = new FileStream(fullPath7, FileMode.Create))
                //{
                //    image7.CopyTo(stream);
                //}
                //dynamicHome.headerBackgroud = imageName7;


                //var image8 = Request.Form.Files[7];
                //var imageName8 = Guid.NewGuid() + "_" + image8.FileName;
                //var fullPath8 = Path.Combine(dynamicPath, imageName8);
                //using (var stream = new FileStream(fullPath8, FileMode.Create))
                //{
                //    image8.CopyTo(stream);
                //}
                //dynamicHome.faviconIcon = imageName8;

                //var image9 = Request.Form.Files[8];
                //var imageName9 = Guid.NewGuid() + "_" + image9.FileName;
                //var fullPath9 = Path.Combine(dynamicPath, imageName9);
                //using (var stream = new FileStream(fullPath9, FileMode.Create))
                //{
                //    image9.CopyTo(stream);
                //}
                //dynamicHome.aboutBackground = imageName9;



                //var image10 = Request.Form.Files[9];
                //var imageName10 = Guid.NewGuid() + "_" + image10.FileName;
                //var fullPath10 = Path.Combine(dynamicPath, imageName10);
                //using (var stream = new FileStream(fullPath10, FileMode.Create))
                //{
                //    image10.CopyTo(stream);
                //}
                //dynamicHome.contactImage = imageName10;


                return dynamicHome;
            }

            catch (Exception)
            {
                return null;
            }
        }
        #endregion UploadImage
        }
    }
