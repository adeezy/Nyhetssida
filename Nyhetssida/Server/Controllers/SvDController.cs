using Microsoft.AspNetCore.Mvc;
using Nyhetssida.Server.Services;
using Nyhetssida.Shared;
using System.Xml;

namespace Nyhetssida.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SvDController : Controller
    {

        private readonly IRssService _rssService;
        public SvDController(IRssService rssService)
        {
            _rssService = rssService;
        }

        //Hämtar alla nyheter från SVD och sorterar på datum
        [HttpGet]
        public List<Post> Get()
        {
            var url = "https://www.svd.se/?service=rss";
            var svdPosts = _rssService.ParseSingleRss(url);
            var postsInOrder = svdPosts.OrderByDescending(x => x.PubDate).ToList();


            return postsInOrder;
        }
    }
}
