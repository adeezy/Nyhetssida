using Microsoft.AspNetCore.Mvc;
using Nyhetssida.Server.Repository;
using Nyhetssida.Shared;
using Nyhetssida.Server.Models;


namespace Nyhetssida.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly ISourceRepository _sourceRepository;


        //Vissar alla källor i admin sidar och hämtar från Source Repository
        public AdminController(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetVisualProjects()
        {
            try
            {
                return Ok(await _sourceRepository.GetSources());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }

        //Lägger till källor från Admin sidan
        [HttpPost]
        public async Task<ActionResult<Shared.Source>> AddSource(Shared.Source source)
        {
            try
            {
                if (source == null)
                    return BadRequest();

                var ModelSource = new Models.Source
                {
                    NewsSource = source.NewsSource
                };

                var addedSource = await _sourceRepository.AddSource(ModelSource);


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Kunde inte lägga till källa");
            }
        }
    }
}
