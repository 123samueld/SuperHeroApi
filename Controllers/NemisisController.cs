namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NemisisController : ControllerBase
    {
        private readonly INemisisRepository _nemisisRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public NemisisController(
            INemisisRepository nemisisRepository,
            IPersonRepository personRepository,
            IMapper mapper)
        {
            _nemisisRepository = nemisisRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Nemisis>))]
        public IActionResult GetNemeses()
        {
            var nemeses = _mapper.Map<List<NemisisDto>>(_nemisisRepository.GetNemeses());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nemeses);
        }

        [HttpGet("{nemisisId}")]
        [ProducesResponseType(200, Type = typeof(Nemisis))]
        [ProducesResponseType(400)]
        public IActionResult GetNemisis(int nemisisId)
        {
            if (!_nemisisRepository.NemisisExists(nemisisId))
                return NotFound();

            var nemisis = _mapper.Map<NemisisDto>(_nemisisRepository.GetNemisis(nemisisId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nemisis);
        }
        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult CreateNemisis([FromQuery] int personId, [FromBody] NemisisDto nemisisCreate)
        {
            if (nemisisCreate == null)
                return BadRequest(ModelState);

            var nemeses = _nemisisRepository.GetNemeses()
                .Where(p => p.Name.Trim().ToUpper() == nemisisCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (nemeses != null)
            {
                ModelState.AddModelError("", "Sorry, this nemisis already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nemisisMap = _mapper.Map<Nemisis>(nemisisCreate);
            
            nemisisMap.Person = _personRepository.GetPerson(personId);

            if (!_nemisisRepository.CreateNemisis(nemisisMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to add this nemisis.");

            }

            return Ok("You have successfully added a new nemisis.");
        }

        [HttpPut("{nemisisId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateNemisis(int nemisisId, [FromBody] NemisisDto updatedNemisis)
        {
            if (updatedNemisis == null)
                return BadRequest(ModelState);

            if (nemisisId != updatedNemisis.Id)
                return BadRequest(ModelState);

            if (!_nemisisRepository.NemisisExists(nemisisId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var nemisisMap = _mapper.Map<Nemisis>(updatedNemisis);

            if (!_nemisisRepository.UpdateNemisis(nemisisMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to update this nemisis.");
                return StatusCode(500, ModelState);
            }

            return Ok("You have successfully updated this nemisis.");
        }

        [HttpDelete("{nemisisId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteNemisis(int nemisisId)
        {
            if (!_nemisisRepository.NemisisExists(nemisisId))
                return NotFound();

            var nemisisToDelete = _nemisisRepository.GetNemisis(nemisisId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_nemisisRepository.DeleteNemisis(nemisisToDelete))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to delete that nemisis.");
            }

            return Ok("You have successfully deleted that nemisis.");
        }
    }
}
