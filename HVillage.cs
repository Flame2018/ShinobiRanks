using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShinobiRanks1._0.Data
{
    public class HVillage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HVID { get; set; }

        [Display(Name = "Hidden Village Name")]
        public string HVName { get; set; }

        [Display(Name = "Hidden Village Terrain")]
        public string HVTerrain { get; set; }

        [Display(Name = "Kage Type")]
        public string KageType { get; set; }
    }
}
