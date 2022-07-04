using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MinimumCriteria
    {
        public int MinimumAge { get; set; }
        public List<string> BackgroundIllness { get; set; }
        public string Residence { get; set; }
    }
}
