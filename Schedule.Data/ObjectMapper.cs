using AutoMapper;
using JBJJCoreApp.Web.ViewModels;
using Schedule.Domain;
using Schedule.Domain.Enums;
using System;

namespace Schedule.Data
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
                cfg.CreateMap<ClassType, ClassTypeViewModel>();
                cfg.CreateMap<ClassTypeViewModel, ClassType>();

                cfg.CreateMap<TimeTable, TimeTableViewModel>()
                    .ForMember(vm => vm.DayofWeek, o => o.MapFrom(a => ((DayofWeek)a.DayofWeek).ToString()));
                cfg.CreateMap<TimeTableViewModel, TimeTable>()
                    .ForMember(o => o.DayofWeek, vm => vm.MapFrom(a => (DayofWeek)Enum.Parse(typeof(DayofWeek), a.DayofWeek)));
            });

            _mapper = config.CreateMapper();
        }
    }
}