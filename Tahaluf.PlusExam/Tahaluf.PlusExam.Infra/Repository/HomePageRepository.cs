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
    public class HomePageRepository : IHomePageRepository
    {
        #region Fields
        private readonly IDbContext _dbContext;
        #endregion Fields

        #region Constructor
        public HomePageRepository(IDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        #endregion Constructor

        #region CRUD_HomePage

        public List<HomePage> GetHomePage()
        {
            return _dbContext.Connection.Query<HomePage>(
                "HomePagePackage.GetHomePage",
                commandType: CommandType.StoredProcedure).ToList();
        }

        public bool UpdateHomePage(HomePage homePage)
        {
            #region DynamicParameters
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("H_id",
                homePage.Id,
                dbType: DbType.Int32,
                direction: ParameterDirection.Input);

            parameters.Add("H_Name",
                homePage.SiteName,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("H_email",
                homePage.SiteEmail,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            parameters.Add("H_phoneNum",
                homePage.SitePhoneNumber,
                dbType: DbType.String,
                direction: ParameterDirection.Input);

            #endregion DynamicParameters

            _dbContext.Connection.ExecuteAsync(
                "HomePagePackage.UpdateInfo", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        #endregion CRUD_HomePage
    }
}
