using Microsoft.AspNetCore.Mvc;
using Nyhetssida.Server.Services;
using Nyhetssida.Shared;
using System.Xml;

namespace Nyhetssida.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : Controller
    {
        private readonly IRssService _rssService;
        public FeedController(IRssService rssService)
        {
            _rssService = rssService;
        }

        //Hämtar alla nyheter och sorterar på datum
        [HttpGet]
        public List<Post> Get()
        {
            var urls = new[] { "http://www.expressen.se/Pages/OutboundFeedsPage.aspx?id=3642159&viewstyle=rss", "https://www.svd.se/?service=rss", "https://nt.se/rss/nyheter" };
            var posts = _rssService.ParseMultipleRss(urls);
            var postsInOrder = posts.OrderByDescending(x => x.PubDate).ToList();

            return postsInOrder;
        }


    }
}
