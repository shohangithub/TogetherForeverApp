using System;
using System.Collections.Generic;
using System.Text;

namespace TogetherForeverApp.Models
{
    public class Cost
    {
        public Guid CostId { get; set; }
        public DateTime CostingDate { get; set; }
        public string CostHead { get; set; }
        public decimal Amount { get; set; }
        public Guid CostBy { get; set; }
        public string CostByName { get; set; }
        public Guid AddBy { get; set; }
    }
}
