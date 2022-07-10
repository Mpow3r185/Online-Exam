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
    public class WebsiteDataRepository : IWebsiteDataRepository
    {
        private readonly IDbContext dbContext;

        public WebsiteDataRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool UpdateWebsiteData(WebsiteData websiteData)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("mail",
                websiteData.Email,
                dbType: DbType.String);

            parameters.Add("passw",
                websiteData.Password,
                dbType: DbType.String);

            dbContext.Connection.ExecuteAsync(
                "WebsiteDataPackage.UpdateWebsiteData", parameters,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public WebsiteData GetWebsiteData()
        {
            return dbContext.Connection.Query<WebsiteData>(
                "WebsiteDataPackage.GetWebsiteData",
                commandType: CommandType.StoredProcedure).First();
        }
    }
}
