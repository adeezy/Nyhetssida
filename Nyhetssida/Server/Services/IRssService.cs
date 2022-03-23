using Nyhetssida.Shared;

namespace Nyhetssida.Server.Services
{
    public interface IRssService
    {
        public List<Post> ParseSingleRss(string url);
        public List<Post> ParseMultipleRss(string[] urls);

        public string? GetImage(string description);

        public string paragraphRemover(string description);
    }
}
