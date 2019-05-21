using Schedule.Domain;
using SharedKernel.Data;
using SharedKernel.Interfaces;

namespace Schedule.Data
{
    public class ScheduleUow : IUow
    {
        private ScheduleContext _scheduleContext;

        public ScheduleUow(ScheduleContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        public GenericRepository<ClassType> ClassTypesRepo { get { return new GenericRepository<ClassType>(_scheduleContext); } }
        public GenericRepository<TimeTable> TimeTablesRepo { get { return new GenericRepository<TimeTable>(_scheduleContext); } }

        public void Save()
        {
            _scheduleContext.SaveChanges();
        }

        public void Dispose()
        {
            _scheduleContext.Dispose();
        }
    }
}