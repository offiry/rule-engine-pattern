using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace Infrastructure.Services
{
    public class VaccinceCriteriaHandler : IVaccinceCriteriaHandler
    {
        private readonly IDataLayer _dataLayer;

        public VaccinceCriteriaHandler(IDataLayer dataLayer)
        {
            this._dataLayer = dataLayer;
        }

        public bool CheckRulesForVaccine(PatientDetails patientDetails, IEnumerable<IRuleSet> rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.IsRuleValied(patientDetails))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
