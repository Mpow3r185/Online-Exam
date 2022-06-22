using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.PlusExam.Core.Common;
using Tahaluf.PlusExam.Core.Data;
using Tahaluf.PlusExam.Core.RepositoryInterface;

namespace Tahaluf.PlusExam.Infra.Repository
{
    public class DynamicHomeRepository : IDynamicHomeRepository
    {
        #region Fields
        private readonly IDbContext dbContext;
        #endregion Fields

        #region Constructor
        public DynamicHomeRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        #endregion Constructor
        public List<DynamicHome> GetAll()
        {
            IEnumerable<DynamicHome> result = dbContext.Connection.Query<DynamicHome>("DynamicHomePackage.GetALL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateHome(DynamicHome dynamicHome)
        {
            var parameters = new DynamicParameters();
            parameters.Add("webName", dynamicHome.webSiteName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("darkLogo", dynamicHome.logoDark, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("lightLogo", dynamicHome.logoLight, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("imageSlider1", dynamicHome.imgSlider1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("imageSlider2", dynamicHome.imgSlider2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("imageSlider3", dynamicHome.imgSlider3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("title01", dynamicHome.title1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("subTitle01", dynamicHome.subTitle1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("title02", dynamicHome.title2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("subTitle02", dynamicHome.subTitle2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("popularParag", dynamicHome.popularParagraph, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("footerParag", dynamicHome.footerParagraph, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("footerImg", dynamicHome.footerBackground, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("aboutImg", dynamicHome.aboutBackground, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("aboutParag", dynamicHome.aboutParagraph, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("phoneNum", dynamicHome.phoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("emaill", dynamicHome.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("webAddress", dynamicHome.webSiteName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("contactParag", dynamicHome.contactParagraph, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("contactImg", dynamicHome.contactImage, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("headerImg", dynamicHome.headerBackgroud, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("faviconIconn", dynamicHome.faviconIcon, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("DynamicHomePackage.UpdateHome", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
