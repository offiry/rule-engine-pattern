using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace VaccineService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IVaccinceCriteriaHandler _vaccinceCriteriaHandler;
        private readonly IDataLayer _dataLayer;
        private readonly IEnumerable<IRuleSet> _ruleSets;

        public AppointmentController(IVaccinceCriteriaHandler vaccinceCriteriaHandler, IDataLayer dataLayer, IEnumerable<IRuleSet> ruleSets)
        {
            this._vaccinceCriteriaHandler = vaccinceCriteriaHandler;
            this._dataLayer = dataLayer;
            this._ruleSets = ruleSets;
        }

        public async Task<IActionResult> Get()
        {
            return new JsonResult("Service Online.");
        }

        [Authorize]
        [Route("SetVaccineAppointment")]
        public async Task<IActionResult> SetVaccineAppointment([FromBody] PatientDetails patientDetails)
        {
            try
            {
                if (_vaccinceCriteriaHandler.CheckRulesForVaccine(patientDetails, _ruleSets))
                {
                    var writeToFile = new StringBuilder()
                            .Append(Directory.GetParent(System.Environment.CurrentDirectory).FullName)
                            .Append($"\\VaccineService\\AppointmentsApproved\\{patientDetails.Id}.txt")
                            .ToString();

                    using (var streamWriter = new StreamWriter(writeToFile, append: true))
                    {
                        await streamWriter.WriteLineAsync(DateTime.UtcNow.ToString());
                    }

                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        [Authorize]
        [Route("UpdateMinimumCriteria")]
        public async Task<IActionResult> UpdateMinimumCriteria([FromBody] MinimumCriteria minimumCriteria)
        {
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    _dataLayer.UpdateCriteria(minimumCriteria);
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
