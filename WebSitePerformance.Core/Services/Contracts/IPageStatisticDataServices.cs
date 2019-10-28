using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSitePerformance.Core.Models;

namespace WebSitePerformance.Core.Services.Contracts
{
    public interface IPageStatisticDataServices
    {
        Task Delete(PageStatistic entity);
        Task<PageStatistic> Add(PageStatistic entity);
        Task<PageStatistic> Update(PageStatistic entity);
        Task<PageStatistic> GetById(int Id);
        Task<IEnumerable<PageStatistic>> GetAll();
        IQueryable<PageStatistic> GetItems();
        Task<IEnumerable<PageStatistic>> GetPagesBySiteUrl(string siteUrl);
        Task<IEnumerable<PageStatistic>> GetPagesBySiteUrlAndTestDate(string siteUrl, DateTime dateTime);
        Task<IEnumerable<PageStatistic>> GetPagesBySiteUrlAndPageUrl(string siteUrl, string pageUrl);
    }
}

