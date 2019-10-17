using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShinobiRanks1._0.Data
{
    public class HVGenin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GID { get; set; }

        [Display(Name = "Genin Name")]
        public string GeninName { get; set; }

        [Display(Name = "Genin Team")]
        public string GeninTeam { get; set; }

        [Display(Name = "Genin Chakra Nature")]
        public string GeninCNature { get; set; }

        [Display(Name = "Hidden Village ID")]
        public int HVID { get; set; }
        [ForeignKey("HVID")]
        public HVillage GVillages { get; set; }
    }
}
