using Microsoft.EntityFrameworkCore;
using Nyhetssida.Server.Data;
using Nyhetssida.Server.Models;

namespace Nyhetssida.Server.Repository
{
    public class SourceRepository : ISourceRepository   
    {
        private readonly ApplicationDbContext _appDbContext;
        public SourceRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Lägger till alla källor i databasen
        public async Task<Source> AddSource(Source source)
        {
            var result = await _appDbContext.Source.AddAsync(source);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        //Hämtar alla källor från Databasen
        public async Task<IEnumerable<Source>> GetSources()
        {
            return await _appDbContext.Source.ToListAsync();
        }

    }
}
