namespace JBJJCoreApp.Web.ViewModels
{
    public class SparringDetailsViewModel : VMBase
    {
        public int AttendanceId { get; set; }
        public int PersonId { get; set; }
        public int OutcomeId { get; set; }
        public string TechniqueUsed { get; set; }
        public AttendanceViewModel Attendance { get; set; }
        public PersonSparringPartnerViewModel PersonSparringPartner { get; set; }
        public OutcomeViewModel Outcome { get; set; }
    }
}