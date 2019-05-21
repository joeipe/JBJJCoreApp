using SharedKernel.Interfaces;

namespace DayAtDojo.Domain
{
    public class TimeTableClassAttended : IEntity
    {
        public int Id { get; set; }
        public string DayofWeek { get; set; }
        public int StartTimeHr { get; set; }
        public int StartTimeMin { get; set; }
        public int EndTimeHr { get; set; }
        public int EndTimeMin { get; set; }
        public string ClassType { get; set; }
    }
}