using Ninject;
using Ninject.Web.Common;
using WebSitePerformance.Core.Services.Contracts;
using WebSitePerformance.Core.Services.Implementations;

namespace WebSitePerformance.Dal.Infrastructure
{
    public static class CoreKernel
    {
        public static void Initialize(IKernel kernel)
        {
            kernel.Bind<IPageDataServices>().To<PageDataServices>().InRequestScope();
            DalKernel.Initialize(kernel);
        }
    }
}
