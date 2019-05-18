﻿using SharedKernel;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayAtDojo.Domain
{
    public class TimeTableClassAttended : EntityBase
    {
        public string DayofWeek { get; set; }
        public int StartTimeHr { get; set; }
        public int StartTimeMin { get; set; }
        public int EndTimeHr { get; set; }
        public int EndTimeMin { get; set; }
        public string ClassType { get; set; }
    }
}
