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
        public string BreakFastFlag => "B"; 
        public string BreakFastColor => BreakFast ? "Green" : "Red"; 
        public string LunchFlag => "L"; 
        public string LunchColor => Lunch ? "Green" : "Red"; 
        public string DinnerFlag => "D";
        public string DinnerColor => Dinner ? "Green" : "Red";
    }
}
