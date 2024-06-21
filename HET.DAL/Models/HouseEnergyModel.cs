using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HET.DAL.Models
{
    public class HouseEnergyModel
    {
        [Required]
        [Range(1, 10000, ErrorMessage = "Please enter a valid house area.")]
        public double HouseArea { get; set; }

        [Required]
        public string InsulationType { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Please enter a valid window area.")]
        public double WindowArea { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Please enter a valid number of occupants.")]
        public int NumberOfOccupants { get; set; }

        [Required]
        public string HeatingSystemType { get; set; }

        [Required]
        public string CoolingSystemType { get; set; }

        [Required]
        [Range(0.1, 5, ErrorMessage = "Please enter a valid appliance efficiency.")]
        public double ApplianceEfficiency { get; set; }

        [Required]
        public string LightingType { get; set; }

        [Required]
        [Range(0, 8760, ErrorMessage = "Please enter a valid number of annual sunlight hours.")]
        public int AnnualSunlightHours { get; set; }

        [Required]
        [Range(-50, 50, ErrorMessage = "Please enter a valid outdoor temperature range.")]
        public double OutdoorTemperatureRange { get; set; }

        public double EnergyConsumption { get; set; }
    }
}
