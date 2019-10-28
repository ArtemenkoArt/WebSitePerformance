using Ninject;
using Ninject.Web.Common;
using WebSitePerformance.Core.Helpers;
using WebSitePerformance.Core.Services.Contracts;
using WebSitePerformance.Core.Services.Implementations;

namespace WebSitePerformance.Dal.Infrastructure
{
    public static class CoreKernel
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<IPageStatisticDataServices>().To<PageStatisticDataServices>().InRequestScope();
            kernel.Bind<ISiteStatisticService>().To<SiteStatisticService>().InRequestScope();
            kernel.Bind<IFileParser>().To<RobotsFileParser>().InRequestScope();
            DalKernel.Initialize(kernel);
        }
    }
}
