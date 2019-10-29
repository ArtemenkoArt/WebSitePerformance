using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebSitePerformance.Dal.Context;
using WebSitePerformance.Dal.Entities;

namespace WebSitePerformance.Dal.Repositories.Implementations
{
    public class PageRepository : GenericRepository<PageStatisticDal>, IPageRepository
    {
        public PageRepository(PageDataContext context) : base(context) { }

        public async Task<IEnumerable<PageStatisticDal>> GetPagesBySiteUrl(string siteUrl)
        {
            return await GetBy(c => c.SiteUrl == siteUrl);
        }

        public async Task<IEnumerable<PageStatisticDal>> GetPagesByTestId(string testId)
        {
            return await GetBy(c => c.TestId == testId);
        }

        public async Task<IEnumerable<PageStatisticDal>> GetPagesBySiteUrlAndPageUrl(string siteUrl, string pageUrl)
        {
            return await GetBy(c => c.SiteUrl == siteUrl && c.PageUrl == pageUrl);
        }
    }
}
