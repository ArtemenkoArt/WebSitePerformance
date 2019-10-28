using WebSitePerformance.Core.Models;

namespace WebSitePerformance.Core.Helpers
{
    public interface ISiteMapHandler
    {
        SiteStatisticViewModel GetStatistic(string url);
    }
}
