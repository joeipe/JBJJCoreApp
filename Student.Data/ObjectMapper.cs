using AutoMapper;
using JBJJCoreApp.Web.ViewModels;
using Student.Domain;

namespace Student.Data
{
    public static class ObjectMapper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        static ObjectMapper()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Grade, GradeViewModel>();
                cfg.CreateMap<GradeViewModel, Grade>();

                cfg.CreateMap<Person, PersonViewModel>();
                cfg.CreateMap<PersonViewModel, Person>();
            });

            _mapper = config.CreateMapper();
        }
    }
}