using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSitePerformance.Core.Helpers
{
    public interface IFileParser
    {
        string GetSitemapUrl(string url);
    }
}
