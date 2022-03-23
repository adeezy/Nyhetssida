using Microsoft.AspNetCore.Mvc;
using Nyhetssida.Server.Services;
using Nyhetssida.Shared;
using System.Xml;

namespace Nyhetssida.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExpressenController : Controller
    {
        private readonly IRssService _rssService;
        public ExpressenController(IRssService rssService)
        {
            _rssService = rssService;
        }

        //Hämtar alla nyheter från Expressen och sorterar på datum
        [HttpGet]
        public List<Post> Get()
        {
            var url = "http://www.expressen.se/Pages/OutboundFeedsPage.aspx?id=3642159&viewstyle=rss";
            var expressenPosts = _rssService.ParseSingleRss(url);
            var postsInOrder = expressenPosts.OrderByDescending(x => x.PubDate).ToList();

            return postsInOrder;
        }
    }
}
