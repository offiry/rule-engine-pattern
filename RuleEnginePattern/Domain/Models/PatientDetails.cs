using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PatientDetails
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public List<string> BackgroundIllness { get; set; }
        public string Residence { get; set; }
    }
}
