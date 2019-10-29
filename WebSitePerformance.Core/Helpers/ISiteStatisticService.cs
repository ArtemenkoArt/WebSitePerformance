using System.Collections.Generic;
using WebSitePerformance.Core.Models;

namespace WebSitePerformance.Core.Helpers
{
    public interface ISiteStatisticService
    {
        List<PageStatistic> GetStatistic(string url);
    }
}
