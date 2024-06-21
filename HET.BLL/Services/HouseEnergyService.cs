using HET.BLL.Services.Interfaces;
using HET.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HET.BLL.Services
{
    public class HouseEnergyService : IHouseEnergyService
    {
        public double CalculateEnergyConsumption(HouseEnergyModel model)
        {
            // Business logic for energy consumption calculation
            double baseEnergyConsumption = model.HouseArea * 0.2; // base energy consumption per square meter

            double insulationFactor = GetInsulationFactor(model.InsulationType);
            double windowFactor = model.WindowArea * 0.05;
            double occupantFactor = model.NumberOfOccupants * 0.1;
            double heatingFactor = GetHeatingSystemFactor(model.HeatingSystemType);
            double coolingFactor = GetCoolingSystemFactor(model.CoolingSystemType);
            double applianceFactor = model.ApplianceEfficiency * 0.1;
            double lightingFactor = GetLightingFactor(model.LightingType);
            double sunlightFactor = model.AnnualSunlightHours * 0.001;
            double temperatureFactor = model.OutdoorTemperatureRange * 0.2;

            double totalEnergyConsumption = baseEnergyConsumption
                                            * insulationFactor
                                            / windowFactor
                                            * occupantFactor
                                            * heatingFactor
                                            * coolingFactor
                                            * applianceFactor
                                            * lightingFactor
                                            / sunlightFactor
                                            * temperatureFactor;

            // Normalize to kWh/m^2 per year
            double energyConsumptionPerYear = totalEnergyConsumption / model.HouseArea;

            // Optionally, round or format energyConsumptionPerYear as needed

            return energyConsumptionPerYear;
        }

        private double GetInsulationFactor(string insulationType)
        {
            // Simplified: Assign factors based on insulation type
            return insulationType switch
            {
                "High" => 1.1,
                "Medium" => 1.2,
                "Low" => 1.3,
                _ => 1.2
            };
        }

        private double GetHeatingSystemFactor(string heatingSystemType)
        {
            // Simplified: Assign factors based on heating system type
            return heatingSystemType switch
            {
                "Gas" => 1.2,
                "Electric" => 1.5,
                "Heat Pump" => 1.1,
                _ => 1.5
            };
        }

        private double GetCoolingSystemFactor(string coolingSystemType)
        {
            // Simplified: Assign factors based on cooling system type
            return coolingSystemType switch
            {
                "Central AC" => 1.5,
                "Window Units" => 1.2,
                _ => 1.5
            };
        }

        private double GetLightingFactor(string lightingType)
        {
            // Simplified: Assign factors based on lighting type
            return lightingType switch
            {
                "LED" => 1.5,
                "CFL" => 1.7,
                "Incandescent" => 1.9,
                _ => 1.5
            };
        }
    }
}
