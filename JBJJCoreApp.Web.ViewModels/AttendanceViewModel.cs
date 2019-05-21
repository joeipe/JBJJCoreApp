using System;
using System.Collections.Generic;

namespace JBJJCoreApp.Web.ViewModels
{
    public class AttendanceViewModel : VMBase
    {
        public int TimeTableId { get; set; }
        public DateTime AttendedOn { get; set; }
        public string TechniqueOfTheDay { get; set; }
        public TimeTableClassAttendedViewModel TimeTableClassAttended { get; set; }
    }

    public class AttendanceDetailedViewModel : AttendanceViewModel
    {
        public List<SparringDetailsViewModel> SparringDetails { get; set; }
    }
}