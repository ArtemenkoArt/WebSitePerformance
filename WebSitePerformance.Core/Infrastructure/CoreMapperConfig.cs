using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSitePerformance.Core.Infrastructure
{
    public static class CoreMapperConfig
    {
        public static void Initialize(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<CoreMapperProfile>();
        }
    }
}
