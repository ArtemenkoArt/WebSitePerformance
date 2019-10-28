using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSitePerformance.Dal.Repositories;

namespace WebSitePerformance.Dal.Entities
{
    public interface IPageDataRepository : IRepository<PageStatisticDal>
    {
        Task<IEnumerable<PageStatisticDal>> GetPagesBySiteUrl(string siteUrl);
        Task<IEnumerable<PageStatisticDal>> GetPagesBySiteUrlAndTestDate(string siteUrl, DateTime dateTime);
        Task<IEnumerable<PageStatisticDal>> GetPagesBySiteUrlAndPageUrl(string siteUrl, string pageUrl);
    }
}
