using Schedule.Domain.Enums;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Domain
{
    public class TimeTable : EntityBase
    {
        public DayofWeek DayofWeek { get; set; }
        public int StartTimeHr { get; set; }
        public int StartTimeMin { get; set; }
        public int EndTimeHr { get; set; }
        public int EndTimeMin { get; set; }
        public int ClassTypeId { get; set; }
        public ClassType ClassType { get; set; }
    }
}
