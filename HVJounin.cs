using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShinobiRanks1._0.Data
{
    public class HVJounin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JID { get; set; }

        [Display(Name = "Jounin Name")]
        public string JouninName { get; set; }

        [Display(Name = "Chakra Nature")]
        public string JouninCNature { get; set; }

        [Display(Name = "Assigned Team")]
        public string ATeam { get; set; }

        [Display(Name = "Hidden Village ID")]
        public int HVID { get; set; }
        [ForeignKey("HVID")]
        public HVillage JVillages { get; set; }
    }
}
