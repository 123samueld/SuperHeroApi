namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisguiseController : ControllerBase
    {
        private readonly IDisguiseRepository _disguiseRepository;
        private readonly IMapper _mapper;

        public DisguiseController(IDisguiseRepository disguiseRepository, IMapper mapper)
        {
            _disguiseRepository = disguiseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Disguise>))]
        public IActionResult GetPeople()
        {
            var disguises = _mapper.Map<List<DisguiseDto>>(_disguiseRepository.GetDisguises());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(disguises);
        }

        [HttpGet("{disguiseId}")]
        [ProducesResponseType(200, Type = typeof(Disguise))]
        [ProducesResponseType(400)]
        public IActionResult GetDisguise(int disguiseId)
        {
            if (!_disguiseRepository.DisguiseExists(disguiseId))
                return NotFound();

            var disguise = _mapper.Map<DisguiseDto>(_disguiseRepository.GetDisguise(disguiseId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(disguise);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDisguise([FromBody] DisguiseDto disguiseCreate)
        {
            if (disguiseCreate == null)
                return BadRequest(ModelState);

            var disguise = _disguiseRepository.GetDisguises()
                .Where(p => p.HeroName.Trim().ToUpper() == disguiseCreate.HeroName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (disguise != null)
            {
                ModelState.AddModelError("", "Sorry, this disguise already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var disguiseMap = _mapper.Map<Disguise>(disguiseCreate);

            if (!_disguiseRepository.CreateDisguise(disguiseMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to add this disguise.");

            }

            return Ok("You have successfully added a new disguise.");
        }

        [HttpPut("{disguiseId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDisguise(int disguiseId, [FromBody] DisguiseDto updatedDisguise)
        {
            if (updatedDisguise == null)
                return BadRequest(ModelState);

            if (disguiseId != updatedDisguise.Id)
                return BadRequest(ModelState);

            if (!_disguiseRepository.DisguiseExists(disguiseId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var disguiseMap = _mapper.Map<Disguise>(updatedDisguise);

            if(!_disguiseRepository.UpdateDisguise(disguiseMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to update the disguise.");
                return StatusCode(500, ModelState);
            }

            return Ok("You have successfully updated this disguise.");
        }

        [HttpDelete("{disguiseId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDisguise(int disguiseId)
        {
            if (!_disguiseRepository.DisguiseExists(disguiseId))
                return NotFound();

            var disguiseToDelete = _disguiseRepository.GetDisguise(disguiseId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_disguiseRepository.DeleteDisguise(disguiseToDelete))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to delete that disguise.");
            }

            return Ok("You have successfully deleted that disguise.");
        }
    }
}
