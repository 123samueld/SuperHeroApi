namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Person>))]
        public IActionResult GetPeople()
        {
            var people = _personRepository.GetPeople();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(people);
        }
    }
}
