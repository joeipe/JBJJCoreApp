using JBJJCoreApp.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using Schedule.Domain;
using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Data.Services
{
    public class ScheduleData
    {
        private GenericRepository<ClassType> _classTypeRepo;
        private GenericRepository<TimeTable> _timeTableRepo;

        public ScheduleData(GenericRepository<ClassType> classTypeRepo, GenericRepository<TimeTable> timeTableRepo)
        {
            _classTypeRepo = classTypeRepo;
            _timeTableRepo = timeTableRepo;
        }

        #region ClassType
        public IList<ClassTypeViewModel> GetClassType()
        {
            var classTypesData = _classTypeRepo.GetAll();
            var classTypesVM = ObjectMapper.Mapper.Map<IList<ClassTypeViewModel>>(classTypesData);
            return classTypesVM;
        }

        public ClassTypeViewModel GetClassTypeById(int id)
        {
            var classTypeData = _classTypeRepo.GetById(id);
            var classTypeVM = ObjectMapper.Mapper.Map<ClassTypeViewModel>(classTypeData);
            return classTypeVM;
        }

        public void AddClassType(ClassTypeViewModel value)
        {
            var classTypeData = ObjectMapper.Mapper.Map<ClassType>(value);
            _classTypeRepo.Add(classTypeData);
        }

        public void UpdateClassType(ClassTypeViewModel value)
        {
            var classTypeData = ObjectMapper.Mapper.Map<ClassType>(value);
            _classTypeRepo.Edit(classTypeData);
        }

        public void DeleteClassType(ClassTypeViewModel value)
        {
            var classTypeData = ObjectMapper.Mapper.Map<ClassType>(value);
            _classTypeRepo.Delete(classTypeData);
        }
        #endregion

        #region TimeTable
        public IList<TimeTableViewModel> GetTimeTable()
        {
            var timeTablesData = _timeTableRepo.GetAll();
            //var timeTablesData = _timeTableRepo.SearchForInclude(x => x.Id>0, i => i.ClassType);
            var timeTablesVM = ObjectMapper.Mapper.Map<IList<TimeTableViewModel>>(timeTablesData);
            return timeTablesVM;
        }

        public TimeTableViewModel GetTimeTableById(int id)
        {
            var timeTableData = _timeTableRepo.GetById(id);
            var timeTableVM = ObjectMapper.Mapper.Map<TimeTableViewModel>(timeTableData);
            return timeTableVM;
        }

        public TimeTableViewModel GetTimeTableWithClassTypeById(int id)
        {
            var timeTableData = _timeTableRepo
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
            _timeTableRepo.Add(timeTableData);
        }

        public void UpdateTimeTable(TimeTableViewModel value)
        {
            var timeTableData = ObjectMapper.Mapper.Map<TimeTable>(value);
            _timeTableRepo.Edit(timeTableData);
        }

        public void DeleteTimeTable(TimeTableViewModel value)
        {
            var timeTableData = ObjectMapper.Mapper.Map<TimeTable>(value);
            _timeTableRepo.Delete(timeTableData);
        }
        #endregion
    }
}
