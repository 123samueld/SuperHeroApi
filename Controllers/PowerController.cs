using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IPowerRepository _powerRepository;
        private readonly IMapper _mapper;

        public PowerController(IPowerRepository powerRepository, IMapper mapper)
        {
            _powerRepository = powerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Power>))]
        public IActionResult GetPowers()
        {
            var powers = _mapper.Map<List<PowerDto>>(_powerRepository.GetPowers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(powers);
        }

        [HttpGet("{powerId}")]
        [ProducesResponseType(200, Type = typeof(Power))]
        [ProducesResponseType(400)]
        public IActionResult GetPower(int powerId)
        {
            if (!_powerRepository.PowerExists(powerId))
                return NotFound();

            var power = _mapper.Map<PowerDto>(_powerRepository.GetPower(powerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(power);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePower([FromBody] PowerDto powerCreate)
        {
            if (powerCreate == null)
                return BadRequest(ModelState);

            var power = _powerRepository.GetPowers()
                .Where(p => p.Name.Trim().ToUpper() == powerCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (power != null)
            {
                ModelState.AddModelError("", "Sorry, this power already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var powerMap = _mapper.Map<Power>(powerCreate);

            if (!_powerRepository.CreatePower(powerMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to add this disguise.");

            }

            return Ok("You have successfully added a new disguise.");
        }

        [HttpPut("{powerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePower(int powerId, [FromBody] PowerDto updatedPower)
        {
            if (updatedPower == null)
                return BadRequest(ModelState);

            if (powerId != updatedPower.Id)
                return BadRequest(ModelState);

            if (!_powerRepository.PowerExists(powerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var powerMap = _mapper.Map<Power>(updatedPower);

            if (!_powerRepository.UpdatePower(powerMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to update this power.");
                return StatusCode(500, ModelState);
            }

            return Ok("You have successfully updated this power.");
        }

        [HttpDelete("{powerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePower(int powerId)
        {
            if (!_powerRepository.PowerExists(powerId))
                return NotFound();

            var powerToDelete = _powerRepository.GetPower(powerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_powerRepository.DeletePower(powerToDelete))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to delete that power.");
            }

            return Ok("You have successfully deleted that power.");
        }
    }
}
