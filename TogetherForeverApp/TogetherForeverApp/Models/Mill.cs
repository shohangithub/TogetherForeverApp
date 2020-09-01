using System;

namespace TogetherForeverApp.Models
{
    public class Mill
    {
        public string MillId { get; set; }
        public string MemberId { get; set; }
        public DateTime MillDate { get; set; }
        public bool BreakFast { get; set; }
        public bool Lunch { get; set; }
        public bool Dinner { get; set; }
        public string ManagerId { get; set; }
        public string MemberName { get; set; }
    }
}
