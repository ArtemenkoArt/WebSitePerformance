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
            kernel.Bind<IPageDataServices>().To<PageDataServices>().InRequestScope();
            kernel.Bind<ISiteMapHandler>().To<SiteMapHandler>().InRequestScope();
            kernel.Bind<IFileParser>().To<RobotsFileParser>().InRequestScope();
            DalKernel.Initialize(kernel);
        }
    }
}
