using System.Data.Entity;
using WebSitePerformance.Dal.Entities;

namespace WebSitePerformance.Dal.Context
{
    public class PageDataContext : DbContext , IPageDataContext
    {
        public DbSet<PageStatisticDal> ProductCategories { get; set; }
        
        public PageDataContext() : base("PageStatistic")
        {
        }

        public PageDataContext(string connectionString) : base(connectionString)
        {
        }
    }
}
