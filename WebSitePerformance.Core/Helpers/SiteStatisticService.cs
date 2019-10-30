using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using WebSitePerformance.Core.Models;

namespace WebSitePerformance.Core.Helpers
{
    public class SiteStatisticService : ISiteStatisticService
    {
        private HttpWebRequest _request;
        private HttpWebResponse _response;
        private IFileParser _parser;
        private ISiteLinksParser _siteParser;

        public SiteStatisticService(IFileParser parser, ISiteLinksParser siteParser)
        {
            _parser = parser;
            _siteParser = siteParser;
        }

        private bool GetPagePerformanse(string pageUrl, out int response)
        {
            response = 0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                _request = (HttpWebRequest)WebRequest.Create(pageUrl);
                _request.Credentials = CredentialCache.DefaultCredentials;
                _response = (HttpWebResponse)_request.GetResponse();

                using (Stream dataStream = _response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                }
                response = (int)stopWatch.ElapsedMilliseconds;
            }
            catch
            {
                return true;
            }
            finally
            {
                stopWatch.Stop();
            }
            return false;
        }

        public List<PageStatistic> GetStatistic(string url)
        {
            var pageUrlList = GetPageList(url);
            var testId = Guid.NewGuid().ToString("N");
            List<PageStatistic> pageList = new List<PageStatistic>();
            var testDate = DateTime.Now;
            foreach (string page in pageUrlList)
            {
                pageList.Add(new PageStatistic()
                {
                    SiteUrl = url,
                    PageUrl = page,
                    TestDate = testDate,
                    TestId = testId,
                    ResponseError = GetPagePerformanse(page, out int response),
                    Response = response,
                });
            }

            return pageList;
        }

        private List<string> GetPageList(string url)
        {
            string sitemap = _parser.GetSitemapUrl(url);
            if (String.IsNullOrEmpty(sitemap))
            {
                return new List<string>();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(sitemap);
            XmlNodeList xmlList = xmlDoc.GetElementsByTagName("loc");

            var sitemapList =  xmlList.Cast<XmlNode>().Select(node => node.InnerText).ToList();

            if (sitemapList.Count == 0)
            {
                return _siteParser.GetWebsiteAllLinks(url);
            }

            return sitemapList;
        }
    }

}
