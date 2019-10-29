using Ninject;
using Ninject.Web.Common;
using WebSitePerformance.Dal.Context;
using WebSitePerformance.Dal.Entities;
using WebSitePerformance.Dal.Repositories.Implementations;

namespace WebSitePerformance.Dal.Infrastructure
{
    public static class DalKernel
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<IPageDataContext>().To<PageDataContext>();
            kernel.Bind<IPageRepository>().To<PageRepository>().InRequestScope();
        }
    }
}
