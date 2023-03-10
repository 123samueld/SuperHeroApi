using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPowerRepository _powerRepository;
        private readonly IMapper _mapper;

        public PersonController(
            IPersonRepository personRepository,
            IPowerRepository powerRepository,
            IMapper mapper)
        {
            _personRepository = personRepository;
            _powerRepository = powerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Person>))]
        public IActionResult GetPeople()
        {
            var people = _mapper.Map<List<PersonDto>>(_personRepository.GetPeople());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(people);
        }

        [HttpGet("{personId}")]
        [ProducesResponseType(200, Type = typeof(Person))]
        [ProducesResponseType(400)]
        public IActionResult GetPerson(int personId)
        {
            if (!_personRepository.PersonExists(personId))
                return NotFound();

            var person = _mapper.Map<PersonDto>(_personRepository.GetPerson(personId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(person);
        }

        [HttpGet("{personId}/nemisis")]
        [ProducesResponseType(200, Type = typeof(Person))]
        [ProducesResponseType(400)]
        public IActionResult GetNemesesOfAPerson(int personId)
        {
            if (!_personRepository.PersonExists(personId))
                return NotFound();

            var personsNemeses = _mapper.Map<NemisisDto>(_personRepository.GetTheNemesesOfAPerson(personId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(personsNemeses);


        }
        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult CreatePerson([FromQuery]int powerId, [FromBody] PersonDto personCreate)
        {
            if (personCreate == null)
                return BadRequest(ModelState);

            var people = _personRepository.GetPersonTrimToUpper(personCreate);

            var person = _personRepository.GetPeople()
                .Where(p => p.LastName.Trim().ToUpper() == personCreate.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (person != null)
            {
                ModelState.AddModelError("", "Sorry, this person already exists.");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var personMap = _mapper.Map<Person>(personCreate);

            if (!_personRepository.CreatePerson(powerId, personMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to add this person.");

            }

            return Ok("You have successfully added a new person.");
        }

        [HttpPut("{personId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePerson(int personId, [FromBody] PersonDto updatedPerson)
        {
            if (updatedPerson == null)
                return BadRequest(ModelState);

            if (personId != updatedPerson.Id)
                return BadRequest(ModelState);

            if (!_personRepository.PersonExists(personId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var personMap = _mapper.Map<Person>(updatedPerson);

            if (!_personRepository.UpdatePerson(personMap))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to update this person.");
                return StatusCode(500, ModelState);
            }

            return Ok("You have successfully updated this person.");
        }

        [HttpDelete("{personId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePerson(int personId)
        {
            if (!_personRepository.PersonExists(personId))
                return NotFound();

            var personToDelete = _personRepository.GetPerson(personId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_personRepository.DeletePerson(personToDelete))
            {
                ModelState.AddModelError("", "Sorry, something went wrong while trying to delete that person.");
            }

            return Ok("You have successfully deleted that person.");
        }
    }
}
