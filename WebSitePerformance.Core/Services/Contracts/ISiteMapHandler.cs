using System.Collections.Generic;
using WebSitePerformance.Core.Models;

namespace WebSitePerformance.Core.Services.Contracts
{
    public interface ISiteMapHandler
    {
        IEnumerable<SiteStatistic> GetSitePageUrl();
    }
}
