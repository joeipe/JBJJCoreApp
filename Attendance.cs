using System;

public class Attendance : EntityBase
{
    public int TimeTableId { get; set; }
    public DateTime AttendedOn { get; set; }
    public string TechniqueOfTheDay { get; set; }
    public List<SparringDetails> SparringDetails { get; set; }
    public TimeTableClassAttended TimeTableClassAttended { get; set; }
}
