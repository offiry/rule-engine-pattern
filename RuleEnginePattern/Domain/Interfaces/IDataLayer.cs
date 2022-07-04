using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDataLayer
    {
        void UpdateCriteria(Models.MinimumCriteria minimumCriteria);
        MinimumCriteria GetMinimumCriteria();
    }
}
