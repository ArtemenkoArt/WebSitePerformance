﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using WebSitePerformance.Core.Models;

namespace WebSitePerformance.Core.Services.Implementations
{
    public static class SiteMapHandler
    {
        private static HttpWebRequest _request;
        private static HttpWebResponse _response;
        private static bool _exitTimer = true;

        private static void ChangeTimerStatus()
        {
            _exitTimer = _exitTimer = true ? false : true;
        }

        private static bool GetPagePerformanse(string pageUrl, out int response)
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

        public static SiteStatisticViewModel GetStatistic(string url)
        {
            var pageList = GetPageList(url);

            List<PageStatistic> pageStatisticList = new List<PageStatistic>();

            foreach (string page in pageList)
            {
                pageStatisticList.Add(new PageStatistic()
                                        {
                                            SiteUrl = url,
                                            PageUrl = page,
                                            TestDate = DateTime.Now,
                                            ResponseError = GetPagePerformanse(page, out int response),
                                            Response = response,
                                            ResponseMax = 0, //TODO: get max and min in repository
                                            ResponseMin = 0
                });
            }

            return new SiteStatisticViewModel()
            {
                SiteUrl = pageStatisticList.Max(n => n.SiteUrl),
                TestDate = pageStatisticList.Min(d => d.TestDate),
                PageList = pageStatisticList.OrderByDescending(x => x.Response).ToList()
            };   
        }

        private static List<string> GetPageList(string url)
        {
            string sitemap = RobotsFileParser.GetSitemapUrl(url);
            if (String.IsNullOrEmpty(sitemap))
            {
                return new List<string>();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(sitemap);
            XmlNodeList xmlList = xmlDoc.GetElementsByTagName("loc");
            return xmlList.Cast<XmlNode>().Select(node => node.InnerText).ToList();
        }
    }
}