using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using WebSitePerformance.Core.Helpers;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Core.Services.Contracts;
using System.Threading.Tasks;
using System;

namespace WebSitePerformance.Web.Controllers
{
    public class PerformanceController : Controller
    {
        private ISiteStatisticService _handler;
        private IPageService _service;

        public PerformanceController(ISiteStatisticService handler, IPageService service)
        {
            _handler = handler;
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetStatistics(string siteUrl)
        {
            List<PageStatistic> pageList = _handler.GetStatistic(siteUrl);
            await SaveStatistics(pageList);
            //return View(await ShowStatistics(pageList.Max(s => s.TestId)));
            return RedirectToAction("ShowStatistics", new { testId = pageList.Max(s => s.TestId), siteId = "" });
        }

        private async Task SaveStatistics(List<PageStatistic> pageList)
        {
            try
            {
                for (int i = 0; i < pageList.Count; i++)
                {
                    await _service.Add(pageList[i]);
                }
            }
            catch { }
        }

        [HttpGet]
        public async Task<ActionResult> ShowStatistics(string testId, string siteId ="")
        {
            return await ShowStatistics(testId);
        }

        [HttpPost]
        public async Task<ActionResult> ShowStatistics(string testId)
        {
            try
            {
                var pageList = await _service.GetPagesByTestId(testId);

                foreach (var page in pageList)
                {
                    var listStatistic = await _service.GetPagesBySiteUrlAndPageUrl(page.SiteUrl, page.PageUrl);
                    page.ResponseMax = listStatistic.Max(p => p.Response);
                    page.ResponseMin = listStatistic.Min(p => p.Response);
                }

                SiteStatisticViewModel siteStatistics = new SiteStatisticViewModel()
                {
                    SiteUrl = pageList.Max(d => d.SiteUrl),
                    TestDate = pageList.Max(d => d.TestDate),
                    PageList = pageList.OrderByDescending(p => p.Response).ToList()
                };

                return View(siteStatistics);
            }
            catch
            {
                return RedirectToAction("Index");
                
            }
        }

        public async Task<ActionResult> ShowHistory(string siteUrl, string pageUrl = "")
        {
            try
            {
                if (string.IsNullOrEmpty(pageUrl))
                {
                    return View(await _service.GetPagesBySiteUrl(siteUrl));
                }
                else
                {
                    return View(await _service.GetPagesBySiteUrlAndPageUrl(siteUrl, pageUrl));
                }
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }
    }
}
