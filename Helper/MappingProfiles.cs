namespace SuperHeroApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<NemisisDto, Nemisis>();
            CreateMap<Nemisis, NemisisDto>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Power, PowerDto>();
            CreateMap<PowerDto, Power>();
        }
    }
}
    