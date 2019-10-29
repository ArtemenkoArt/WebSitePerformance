using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSitePerformance.Dal.Repositories;

namespace WebSitePerformance.Dal.Entities
{
    public interface IPageRepository : IRepository<PageStatisticDal>
    {
        Task<IEnumerable<PageStatisticDal>> GetPagesBySiteUrl(string siteUrl);
        Task<IEnumerable<PageStatisticDal>> GetPagesByTestId(string testId);
        Task<IEnumerable<PageStatisticDal>> GetPagesBySiteUrlAndPageUrl(string siteUrl, string pageUrl);
    }
}
