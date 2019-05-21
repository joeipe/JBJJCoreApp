using SharedKernel;

namespace DayAtDojo.Domain
{
    public class SparringDetails : EntityBase
    {
        public int AttendanceId { get; set; }
        public int PersonId { get; set; }
        public int OutcomeId { get; set; }
        public string TechniqueUsed { get; set; }
        public Attendance Attendance { get; set; }
        public Outcome Outcome { get; set; }
        public PersonSparringPartner PersonSparringPartner { get; set; }
    }
}