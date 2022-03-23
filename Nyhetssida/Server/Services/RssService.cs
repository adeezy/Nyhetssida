using Nyhetssida.Shared;
using System.Xml;

namespace Nyhetssida.Server.Services
{
    public class RssService : IRssService
    {

        // Hämtar RSS från en källa
        public List<Post> ParseSingleRss(string url)
        {
            List<Post> itemList = new List<Post>();
            XmlDocument rssXmlDoc = new XmlDocument();

            rssXmlDoc.Load(url);

            XmlNode rssCategoryNode = rssXmlDoc.SelectSingleNode("rss/channel/title");


            XmlNodeList rssItemNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            foreach (XmlNode rssNode in rssItemNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string pubDate = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                string source = rssCategoryNode != null ? rssCategoryNode.InnerText : string.Empty;

                if (source == "Nyheter")
                {
                    source = "NT";
                }

                itemList.Add(new Post
                {
                    Titel = title,
                    Description = paragraphRemover(description),
                    PubDate = Convert.ToDateTime(pubDate),
                    Link = link,
                    Source = source,
                    Image = GetImage(description)
                });
            }
            return itemList;
        }

        // Hämtar RSS från en flera källor
        public List<Post> ParseMultipleRss(string[] urls)
        {
            List<Post> itemList = new List<Post>();
            foreach (var url in urls)
            {
                XmlDocument rssXmlDoc = new XmlDocument();

                rssXmlDoc.Load(url);

                XmlNode rssSourceNode = rssXmlDoc.SelectSingleNode("rss/channel/title");

                XmlNodeList rssItemNodes = rssXmlDoc.SelectNodes("rss/channel/item");

                foreach (XmlNode rssNode in rssItemNodes)
                {
                    XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                    string title = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                    rssSubNode = rssNode.SelectSingleNode("description");
                    string description = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                    rssSubNode = rssNode.SelectSingleNode("pubDate");
                    string pubDate = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                    rssSubNode = rssNode.SelectSingleNode("link");
                    string link = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                    rssSubNode = rssNode.SelectSingleNode("category");
                    string category = rssSubNode != null ? rssSubNode.InnerText : string.Empty;

                    string source = rssSourceNode != null ? rssSourceNode.InnerText : string.Empty;

                    if (source == "Nyheter")
                    {
                        source = "NT";
                    }

                    itemList.Add(new Post
                    {
                        Titel = title,
                        Image = GetImage(description),
                        Description = paragraphRemover(description),
                        PubDate = Convert.ToDateTime(pubDate),
                        Link = link,
                        Source = source,
                        Category = category,
                    }); ;
                }
            }

            return itemList;
        }

        //Hämtar bild
        public string? GetImage(string description)
        {
            string image = "";
            if (description.Contains("<img") && description.Contains("expressen"))
            {
                image = description.Substring(10, 93);

                return image;
            }

            return null;
        }

        //Raderar paragraf element från texten
        public string paragraphRemover(string description)
        {
            if (description.Contains("<p>") || description.Contains("</p>"))
            {
                description = description.Replace("<p>", "");
                description = description.Replace("</p>", "");
            }

            return description;
        }
    }
}
