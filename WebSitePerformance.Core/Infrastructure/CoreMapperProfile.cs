using AutoMapper;
using WebSitePerformance.Core.Models;
using WebSitePerformance.Dal.Entities;

namespace WebSitePerformance.Core.Infrastructure
{
    public class CoreMapperProfile : Profile
    {
        public CoreMapperProfile()
        {
            CreateMap<PageStatistic, PageStatisticDal>().ReverseMap();
        }
    }
}
