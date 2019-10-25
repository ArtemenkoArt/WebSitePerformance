using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebSitePerformance.Core.Models;

namespace WebSitePerformance.Core
{
    public class SitemapParser
    {
        private string SiteUrl { get; set; }

        public SitemapParser(string siteUrl)
        {
            SiteUrl = siteUrl;
        }

        private bool GetPagePerformanse(string pageUrl, out long performance)
        {
            performance = 0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                WebRequest request = WebRequest.Create(pageUrl);
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                }
                performance = stopWatch.ElapsedMilliseconds;
                return false;
            }
            catch
            {
                performance = stopWatch.ElapsedMilliseconds;
                return true;
            }
            finally
            {
                stopWatch.Stop();
            }
        }

        public IEnumerable<SiteStatistic> GetSitePageUrl()
        {
            List<SiteStatistic> siteStatisticList = new List<SiteStatistic>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(SiteUrl);
            XmlNodeList xnList = xDoc.GetElementsByTagName("loc");
            foreach (XmlNode node in xnList)
            {
                //long performance;
                //bool responseError = GetPagePerformanse(node.InnerText, out long performance);

                siteStatisticList.Add(
                    new SiteStatistic() 
                    {
                        SiteUrl = SiteUrl,
                        PageUrl = node.InnerText,
                        TestDate = DateTime.Now,
                        ResponseError = GetPagePerformanse(node.InnerText, out long performance),
                        Performance = performance
                    });
            }
            return siteStatisticList.OrderBy(x => x.Performance);
        }
    }
}
