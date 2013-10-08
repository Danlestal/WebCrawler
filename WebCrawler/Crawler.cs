using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HtmlAgilityPack;


namespace WebCrawler
{
    public class Crawler
    {

        public Crawler()
        {
        }


        public HtmlDocument ReadWebPage(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }

        public List<string> RetrieveOutputUrls(HtmlDocument document)
        {
            List<string> output = new List<string>();
            foreach(HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                output.Add(att.Value);
            }

            return output;
        }

        public List<string> RetrieveImageLinks(HtmlDocument document)
        {
            List<string> output = new List<string>();
            foreach (HtmlNode link in document.DocumentNode.SelectNodes("//img[@src]"))
            {
                HtmlAttribute att = link.Attributes["src"];
                output.Add(att.Value);
            }

            return output;
        }


    }
}
