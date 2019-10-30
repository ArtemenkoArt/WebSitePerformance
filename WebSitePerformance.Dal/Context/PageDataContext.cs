using System.Data.Entity;
using WebSitePerformance.Dal.Entities;

namespace WebSitePerformance.Dal.Context
{
    public class PageDataContext : DbContext , IPageDataContext
    {
        public DbSet<PageStatisticDal> PageStatisticDal { get; set; }
        
        public PageDataContext() : base("PageStatisticConnectionString") {}
    }
}
