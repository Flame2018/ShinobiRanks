using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShinobiRanks1._0.Data
{
    public class HVChuunin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CID { get; set; }

        [Display(Name = "Chuunin Name")]
        public int ChuuninName { get; set; }

        [Display(Name = "Chuunin Team")]
        public int Team { get; set; }

        [Display(Name = "Chakra Nature")]
        public int ChuuninCNature { get; set; }

        [Display(Name = "Hidden Village ID")]
        public int HVID { get; set; }
        [ForeignKey("HVID")]
        public HVillage CVillages { get; set; }
    }
}
