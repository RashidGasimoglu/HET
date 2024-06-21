using HET.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HET.BLL.Services.Interfaces
{
    public interface IHouseEnergyService
    {
        double CalculateEnergyConsumption(HouseEnergyModel model);
    }
}
