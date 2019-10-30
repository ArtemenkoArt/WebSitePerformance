using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSitePerformance.Core.Helpers
{
    public class SiteLinksParser : ISiteLinksParser
    {
        private Queue<string> testingUrl = new Queue<string>();
        private List<string> processedUrl = new List<string>();

        private string GetNormalUrl(string siteUrl, string link)
        {
            string protocol = siteUrl.Contains("https://") ? "https" : "http";
            string domen = siteUrl.Replace(protocol + "://", "");

            link = link.Trim();

            if (link.StartsWith("//") && link.Length > 2)      //   "//somesite.so/some-text"
            {
                return protocol + ":" + link;
            }
            else if (link.StartsWith("/") && link.Length > 1)  //  "/some-text"
            {
                return siteUrl.EndsWith("/") ? siteUrl + link.Substring(1) : siteUrl + link;
            }

            return link;
        }

        private void GetPageLinks(string siteUrl, string testUrl)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(testUrl);
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a"))
            {
                if (node.Attributes["href"] != null)
                {
                    var link = GetNormalUrl(siteUrl, node.Attributes["href"].Value);
                    if (link.Contains(siteUrl))
                    {
                        if (!processedUrl.Contains(link))
                        {
                            processedUrl.Add(link);
                            testingUrl.Enqueue(link);
                        }
                    }
                }
            }
        }

        public List<string> GetWebsiteAllLinks(string siteUrl)
        {
            testingUrl.Enqueue(siteUrl);

            while (testingUrl.Count > 0)
            {
                GetPageLinks(siteUrl, testingUrl.Dequeue());
            }

            return processedUrl;
        }
    }
}
