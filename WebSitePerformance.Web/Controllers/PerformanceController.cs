using System.Collections.Generic;
using System.Web.Mvc;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Core.Services.Contracts;
using WebSitePerformance.Core.Services.Implementations;

namespace WebSitePerformance.Web.Controllers
{
    public class PerformanceController : Controller
    {
        private SiteMapHandler _siteMapHandler;

        public PerformanceController()
        {
            
        }

        // GET: Performance
        public ActionResult Index()
        {
            return View();
        }

        // GET: Performance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Performance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Performance/Create
        [HttpPost]
        public ActionResult Create(string siteUrl)
        {
            IEnumerable<SiteStatistic> list = SiteMapHandler.GetStatistic(siteUrl);
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
