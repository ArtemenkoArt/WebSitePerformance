using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSitePerformance.Core.Models
{
    public class SiteStatistic
    {
        public int Id { get; set; }
        public string SiteUrl { get; set; }
        public DateTime TestDate { get; set; }
        public string PageUrl { get; set; }
        public long Performance { get; set; }
        public bool ResponseError { get; set; }
    }
}
