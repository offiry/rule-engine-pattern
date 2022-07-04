using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRuleSet
    {
        bool IsRuleValied(PatientDetails patientDetails);
    }
}
