using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSitePerformance.Core.Models
{
    public class PageStatistic
    {
        [Key]
        [ReadOnly(true)]
        public int Id { get; set; }
        [Display(Name = "Test site URL")]
        public string SiteUrl { get; set; }
        [Display(Name = "Test date")]
        public DateTime TestDate { get; set; }
        [Display(Name = "Test page URL")]
        public string PageUrl { get; set; }
        [Display(Name = "Current response")]
        public int Response { get; set; }
        [Display(Name = "Fastest response")]
        public int ResponseMax { get; set; }
        [Display(Name = "Slowest response")]
        public int ResponseMin { get; set; }
        [Display(Name = "Quantity response")]
        public int ResponseQty { get; set; }
        [Display(Name = "Response error")]
        public bool ResponseError { get; set; }
    }
}
