using Nyhetssida.Server.Models;

namespace Nyhetssida.Server.Repository
{
    public interface ISourceRepository
    {
        Task<IEnumerable<Source>> GetSources();

        Task<Source> AddSource(Source source);

    }
}
