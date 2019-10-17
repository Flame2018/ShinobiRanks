using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShinobiRanks1._0.Data
{
    public class HVKage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KID { get; set; }

        [Display(Name = "Kage Name")]
        public string KageName { get; set; }

        [Display(Name = "Chakra Nature")]
        public string KageChakraNature { get; set; }

        [Display(Name = "Hidden Village")]
        public string KVillage { get; set; }

        [Display(Name = "Hidden Village ID")]
        public int HVID { get; set; }
        [ForeignKey("HVID")]
        public HVillage KVillages { get; set; }
    }
}
