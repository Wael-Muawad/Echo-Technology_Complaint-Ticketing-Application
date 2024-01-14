using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Demands
{
    public class DemandCreateDto
    {
        [Required]
        public string DemandDetails { get; set; }

        [Required]
        public int ComplaintID { get; set; }
    }
}
