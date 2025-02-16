namespace HRMS.Core.Entities
{
    public class Shift : BaseEntity
    {
        public string Workdays { get; set; }
        public string Weekoffs { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan BreakStartTime { get; set; }
        public TimeSpan BreakEndTime { get; set; }
        public string ShiftType { get; set; }
        public string Notes { get; set; }
    }
}
