using System.Web.Mvc;
using WebSitePerformance.Core.Helpers;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Core.Services.Contracts;

namespace WebSitePerformance.Web.Controllers
{
    public class PerformanceController : Controller
    {
        private ISiteMapHandler _handler;
        private IPageDataServices _service;

        public PerformanceController(ISiteMapHandler handler, IPageDataServices service)
        {
            _handler = handler;
            _service = service;
        }

        // GET: Performance
        public ActionResult Index()
        {
            return View();
        }

        // GET: Performance/Create
        public ActionResult ShowStatistic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowStatistic(string siteUrl)
        {
            try
            {
                SiteStatisticViewModel siteStatistics = _handler.GetStatistic(siteUrl);
                return View(siteStatistics);
            }
            catch
            {
                return RedirectToAction("Index");
                
            }
        }

        // GET: Performance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Performance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Performance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
