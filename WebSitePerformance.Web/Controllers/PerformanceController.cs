using System.Web.Mvc;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Core.Services.Implementations;

namespace WebSitePerformance.Web.Controllers
{
    public class PerformanceController : Controller
    {
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
                SiteStatisticViewModel siteStatistics = SiteMapHandler.GetStatistic(siteUrl);
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
