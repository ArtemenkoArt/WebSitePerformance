using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using WebSitePerformance.Core.Helpers;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Core.Services.Contracts;
using System.Threading.Tasks;

namespace WebSitePerformance.Web.Controllers
{
    public class PerformanceController : Controller
    {
        private ISiteStatisticService _handler;
        private IPageStatisticDataServices _service;

        public PerformanceController(ISiteStatisticService handler, IPageStatisticDataServices service)
        {
            _handler = handler;
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowStatistic()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ShowStatistic(string siteUrl)
        {
            try
            {
                List<PageStatistic> statisticList = new List<PageStatistic>();
                List<PageStatistic> responceList = _handler.GetStatistic(siteUrl);

                for (int i = 0; i < responceList.Count; i++)
                {
                    statisticList.Add(await _service.Add(responceList[i]));
                    var listStatistic = await _service.GetPagesBySiteUrlAndPageUrl(responceList[i].SiteUrl, responceList[i].PageUrl);
                    statisticList[i].ResponseMax = listStatistic.Max(p => p.Response);
                    statisticList[i].ResponseMin = listStatistic.Min(p => p.Response);
                }

                SiteStatisticViewModel siteStatistics = new SiteStatisticViewModel()
                {
                    SiteUrl = siteUrl,
                    TestDate = statisticList.Max(d => d.TestDate),
                    PageList = statisticList.OrderByDescending(p => p.Response).ToList()
            };

                return View(siteStatistics);
            }
            catch
            {
                return RedirectToAction("Index");
                
            }
        }
    }
}
