using Microsoft.AspNetCore.Mvc;
using Nyhetssida.Server.Services;
using Nyhetssida.Shared;
using System.Xml;

namespace Nyhetssida.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NTController : Controller
    {

        private readonly IRssService _rssService;
        public NTController(IRssService rssService)
        {
            _rssService = rssService;
        }

        //Hämtar alla nyheter från NT och sorterar på datum
        [HttpGet]
        public List<Post> Get()
        {
            var url = "https://nt.se/rss/nyheter";
            var ntPosts = _rssService.ParseSingleRss(url);
            var postsInOrder = ntPosts.OrderByDescending(x => x.PubDate).ToList();

            return postsInOrder;
        }

    }
}
