using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShinobiRanks1._0.Data
{
    public class HVScrolls
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VSID { get; set; }

        [Display(Name = "Scroll Name")]
        public string SName { get; set; }

        [Display(Name = "Hidden Village Scroll")]
        public string HVScroll { get; set; }

        [Display(Name = "Scroll Content")]
        public string SContent { get; set; }

        [Display(Name = "Hidden Village ID")]
        public int HVID { get; set; }
        [ForeignKey("HVID")]
        public HVillage Villages { get; set; }
    }
}
