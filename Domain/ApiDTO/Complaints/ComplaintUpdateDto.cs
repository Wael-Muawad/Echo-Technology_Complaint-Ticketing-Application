using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Complaints
{
    public class ComplaintUpdateDto
    {
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string ComplaintDetails { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public ComplaintStatus ComplaintStatus { get; set; }
    }
}
