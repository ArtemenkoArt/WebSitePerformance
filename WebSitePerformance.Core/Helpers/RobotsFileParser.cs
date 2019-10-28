using System;
using System.IO;
using System.Linq;
using System.Net;

namespace WebSitePerformance.Core.Helpers
{
    public class RobotsFileParser : IFileParser
    {
        private HttpWebRequest _request;
        private HttpWebResponse _response;
        private Stream _stream;


        public string GetSitemapUrl(string url)
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

        private bool TestUrl(string baseUrl)
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

        private void OpenUrl()
        {
            _stream = _response.GetResponseStream();
        }

        private string ReadFile()
        {
            StreamReader sr = new StreamReader(_stream);
            string text = sr.ReadToEnd();
            return text;
        }

        private string[] GetStrings(string text)
        {
            return text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                       .Where(l => !string.IsNullOrWhiteSpace(l))
                       .ToArray();
        }

        private string GetLineField(string line)
        {
            var index = line.IndexOf(':');
            if (index > 0)
            {
                return line.Substring(0, index);
            }
            return "unknow";
        }

        private string GetLineValue(string line, string field)
        {
            return line.Substring(field.Length + 1).Trim();
        }
    }
}
