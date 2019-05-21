using DayAtDojo.Domain;
using SharedKernel.Data;
using SharedKernel.Interfaces;

namespace DayAtDojo.Data
{
    public class DayAtDojoUow : IUow
    {
        private DayAtDojoContext _dayAtDojoContext;
        private ReferenceScheduleContext _referenceScheduleContext;
        private ReferenceStudentContext _referenceStudentContext;

        public DayAtDojoUow(DayAtDojoContext dayAtDojoContext, ReferenceScheduleContext referenceScheduleContext, ReferenceStudentContext referenceStudentContext)
        {
            _dayAtDojoContext = dayAtDojoContext;
            _referenceScheduleContext = referenceScheduleContext;
            _referenceStudentContext = referenceStudentContext;
        }

        public GenericRepository<Outcome> OutcomesRepo { get { return new GenericRepository<Outcome>(_dayAtDojoContext); } }
        public GenericRepository<Attendance> AttendanceRepo { get { return new GenericRepository<Attendance>(_dayAtDojoContext); } }
        public GenericRepository<SparringDetails> SparringDetailsRepo { get { return new GenericRepository<SparringDetails>(_dayAtDojoContext); } }
        public GenericRepository<TimeTableClassAttended> TimeTableClassAttendedRepo { get { return new GenericRepository<TimeTableClassAttended>(_referenceScheduleContext); } }
        public GenericRepository<PersonSparringPartner> PersonSparringPartnersRepo { get { return new GenericRepository<PersonSparringPartner>(_referenceStudentContext); } }

        public void Save()
        {
            _dayAtDojoContext.SaveChanges();
        }

        public void Dispose()
        {
            _dayAtDojoContext.Dispose();
        }
    }
}