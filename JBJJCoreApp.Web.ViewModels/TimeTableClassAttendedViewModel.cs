namespace JBJJCoreApp.Web.ViewModels
{
    public class TimeTableClassAttendedViewModel
    {
        public int Id { get; set; }
        public string DayofWeek { get; private set; }
        public int StartTimeHr { get; private set; }
        public int StartTimeMin { get; private set; }
        public int EndTimeHr { get; private set; }
        public int EndTimeMin { get; private set; }
        public string ClassType { get; private set; }
    }
}