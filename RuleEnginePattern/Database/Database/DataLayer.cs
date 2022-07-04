using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class DataLayer : IDataLayer
    {
        private MinimumCriteria minimumCriteria;
        private readonly object @lock = new object();
        private readonly string criteriaPath;

        public DataLayer()
        {
            criteriaPath = new StringBuilder()
                .Append(Directory.GetParent(System.Environment.CurrentDirectory).FullName)
                .Append("\\Database\\criteria.json")
                .ToString();

            minimumCriteria = Newtonsoft.Json.JsonConvert
                .DeserializeObject<MinimumCriteria>(File.ReadAllText(criteriaPath));
        }

        public void UpdateCriteria(MinimumCriteria minimumCriteria)
        {
            lock (@lock)
            {
                File.WriteAllText(criteriaPath, Newtonsoft.Json.JsonConvert
                    .SerializeObject(minimumCriteria, Newtonsoft.Json.Formatting.Indented));

                minimumCriteria = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<MinimumCriteria>(File.ReadAllText(criteriaPath));
            }
        }

        public MinimumCriteria GetMinimumCriteria()
        {
            lock (@lock)
            {
                return minimumCriteria;
            }
        }
    }
}
