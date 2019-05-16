using System;

namespace JBJJCoreApp.Web.ViewModels
{
    public class TimeTableViewModel : VMBase
    {
        public string DayofWeek { get; set; }
        public int StartTimeHr { get; set; }
        public int StartTimeMin { get; set; }
        public int EndTimeHr { get; set; }
        public int EndTimeMin { get; set; }
        public int ClassTypeId { get; set; }
        public ClassTypeViewModel ClassType { get; set; }
    }
}
