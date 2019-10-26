using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebSitePerformance.Core.Services.Implementations
{
    public static class RobotsFileParser
    {
        private static HttpWebRequest _request;
        private static HttpWebResponse _response;
        private static Stream _stream;

        public static string GetSitemapUrl(string url)
        {
            url += url.EndsWith("/") ? "robots.txt" : "/robots.txt";

            if (!TestUrl(url))
            {
                return string.Empty;
            }
            OpenUrl();

            string text = ReadFile();

            string[] lines = GetStrings(text);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string field = GetLineField(line);
                if (field == "Sitemap")
                {
                    return GetLineValue(line, field);
                }
            }
            return string.Empty;
        }

        private static bool TestUrl(string baseUrl)
        {
            try
            {
                _request = (HttpWebRequest)HttpWebRequest.Create(baseUrl);
                _response = (HttpWebResponse)_request.GetResponse();
                _response.GetResponseStream();
                return (_response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        private static void OpenUrl()
        {
            _stream = _response.GetResponseStream();
        }

        private static string ReadFile()
        {
            StreamReader sr = new StreamReader(_stream);
            string text = sr.ReadToEnd();
            return text;
        }

        private static string[] GetStrings(string text)
        {
            return text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                       .Where(l => !string.IsNullOrWhiteSpace(l))
                       .ToArray();
        }

        private static string GetLineField(string line)
        {
            var index = line.IndexOf(':');
            if (index > 0)
            {
                return line.Substring(0, index);
            }
            return "unknow";
        }

        private static string GetLineValue(string line, string field)
        {
            return line.Substring(field.Length + 1).Trim();
        }
    }
}
