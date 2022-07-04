using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.Rules
{
    public class AgeRule : IRuleSet
    {
        public bool IsRuleValied(PatientDetails patientDetails)
        {
            if (patientDetails.Age > 18)
            {
                return true;
            }

            return false;
        }
    }
}
