using System;
using System.ComponentModel.DataAnnotations;

namespace WebSitePerformance.Dal.Entities
{

    public class PageStatisticDal : IEntities
    {
        [Key]
        public int Id { get; set; }
        public string TestId { get; set; }
        public string SiteUrl { get; set; }
        public DateTime TestDate { get; set; }
        public string PageUrl { get; set; }
        public int Response { get; set; }
        public bool ResponseError { get; set; }
    }
}
