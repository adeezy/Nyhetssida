using Microsoft.AspNetCore.Mvc;
using Nyhetssida.Server.Services;
using Nyhetssida.Shared;
using System.Xml;

namespace Nyhetssida.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IRssService _rssService;
        public CategoryController(IRssService rssService)
        {
            _rssService = rssService;
        }

        //Hämtar alla nyheter från en viss kategori och sorterar på datum
        [HttpGet]
        public List<Post> Get(string category)
        {
            var urls = new[] { "http://www.expressen.se/Pages/OutboundFeedsPage.aspx?id=3642159&viewstyle=rss", "https://www.svd.se/?service=rss" };
            var posts = _rssService.ParseMultipleRss(urls);
            var categoryPosts = posts.Where(x => x.Category?.ToString() == category);
            var postsInOrder = categoryPosts.OrderByDescending(x => x.PubDate).ToList();

            return postsInOrder;
        }


    }
}
