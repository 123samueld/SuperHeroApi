namespace SuperHeroApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Disguise, DisguiseDto>();
            CreateMap<DisguiseDto, Disguise>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<Power, PowerDto>();
            CreateMap<PowerDto, Power>();
        }
    }
}
    