using JBJJCoreApp.Web.ViewModels;
using Schedule.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Data.Services
{
    public class ScheduleData
    {
        private ScheduleUow _scheduleUow;

        public ScheduleData(ScheduleUow scheduleUow)
        {
            _scheduleUow = scheduleUow;
        }

        #region ClassType

        public IList<ClassTypeViewModel> GetClassType()
        {
            var classTypesData = _scheduleUow.ClassTypesRepo.GetAll();
            var classTypesVM = ObjectMapper.Mapper.Map<IList<ClassTypeViewModel>>(classTypesData);
            return classTypesVM;
        }

        public ClassTypeViewModel GetClassTypeById(int id)
        {
            var classTypeData = _scheduleUow.ClassTypesRepo.GetById(id);
            var classTypeVM = ObjectMapper.Mapper.Map<ClassTypeViewModel>(classTypeData);
            return classTypeVM;
        }

        public void AddClassType(ClassTypeViewModel value)
        {
            var classTypeData = ObjectMapper.Mapper.Map<ClassType>(value);
            _scheduleUow.ClassTypesRepo.Add<ClassType>(classTypeData);
            _scheduleUow.Save();
        }

        public void UpdateClassType(ClassTypeViewModel value)
        {
            var classTypeData = ObjectMapper.Mapper.Map<ClassType>(value);
            _scheduleUow.ClassTypesRepo.Edit<ClassType>(classTypeData);
            _scheduleUow.Save();
        }

        public void DeleteClassType(ClassTypeViewModel value)
        {
            var classTypeData = ObjectMapper.Mapper.Map<ClassType>(value);
            _scheduleUow.ClassTypesRepo.Delete(classTypeData);
            _scheduleUow.Save();
        }

        #endregion ClassType

        #region TimeTable

        public IList<TimeTableViewModel> GetTimeTable()
        {
            var timeTablesData = _scheduleUow.TimeTablesRepo.GetAll();
            var timeTablesVM = ObjectMapper.Mapper.Map<IList<TimeTableViewModel>>(timeTablesData);
            return timeTablesVM;
        }

        public IList<TimeTableViewModel> GetTimeTableWithGraph()
        {
            var timeTablesData = _scheduleUow.TimeTablesRepo.SearchForInclude(x => x.Id != 0, i => i.ClassType);
            var timeTablesVM = ObjectMapper.Mapper.Map<IList<TimeTableViewModel>>(timeTablesData);
            return timeTablesVM;
        }

        public TimeTableViewModel GetTimeTableById(int id)
        {
            var timeTableData = _scheduleUow.TimeTablesRepo.GetById(id);
            var timeTableVM = ObjectMapper.Mapper.Map<TimeTableViewModel>(timeTableData);
            return timeTableVM;
        }

        public TimeTableViewModel GetTimeTableWithClassTypeById(int id)
        {
            var timeTableData = _scheduleUow.TimeTablesRepo
                .SearchForInclude
                (
                    t => t.Id == id,
                    i => i.ClassType
                )
                .FirstOrDefault();
            var timeTableVM = ObjectMapper.Mapper.Map<TimeTableViewModel>(timeTableData);
            return timeTableVM;
        }

        public void AddTimeTable(TimeTableViewModel value)
        {
            var timeTableData = ObjectMapper.Mapper.Map<TimeTable>(value);
            _scheduleUow.TimeTablesRepo.Add<TimeTable>(timeTableData);
            _scheduleUow.Save();
        }

        public void UpdateTimeTable(TimeTableViewModel value)
        {
            var timeTableData = ObjectMapper.Mapper.Map<TimeTable>(value);
            _scheduleUow.TimeTablesRepo.Edit<TimeTable>(timeTableData);
            _scheduleUow.Save();
        }

        public void DeleteTimeTable(TimeTableViewModel value)
        {
            var timeTableData = ObjectMapper.Mapper.Map<TimeTable>(value);
            _scheduleUow.TimeTablesRepo.Delete(timeTableData);
            _scheduleUow.Save();
        }

        #endregion TimeTable
    }
}