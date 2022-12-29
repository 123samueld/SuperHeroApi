using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisguiseController : ControllerBase
    {
        private readonly IDisguiseRepository _disguiseRepository;

        public DisguiseController(IDisguiseRepository disguiseRepository)
        {
            _disguiseRepository = disguiseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Disguise>))]
        public IActionResult GetPeople()
        {
            var disguise = _disguiseRepository.GetDisguises();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(disguise);
        }
    }
}
