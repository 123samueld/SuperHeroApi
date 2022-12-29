using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IPowerRepository _powerRepository;

        public PowerController(IPowerRepository powerRepository)
        {
            _powerRepository = powerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Power>))]
        public IActionResult GetPowers()
        {
            var powers = _powerRepository.GetPowers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(powers);
        }
    }
}
