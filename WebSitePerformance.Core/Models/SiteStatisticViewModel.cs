using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSitePerformance.Core.Models
{
    public class SiteStatisticViewModel
    {
        [Display(Name = "Test site URL")]
        public string SiteUrl { get; set; }
        [Display(Name = "Test date")]
        public DateTime TestDate { get; set; }
        public List<PageStatistic> PageList { get; set; }
        [Display(Name = "Quantity page")]
        public int QtyTestPage { get { return PageList.Count; } }
    }
}
