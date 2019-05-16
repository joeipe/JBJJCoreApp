using SharedKernel;
using System;
using System.Collections.Generic;

namespace Schedule.Domain
{
    public class ClassType : EntityBase
    {
        public string Name { get; set; }
        public List<TimeTable> TimeTables { get; set; }
    }
}
