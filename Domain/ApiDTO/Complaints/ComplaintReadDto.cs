using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Complaints
{
    public class ComplaintReadDto
    {
        public string ComplaintDetails { get; set; }
        public string FilePath { get; set; }
        public Priority Priority { get; set; } 
        public ComplaintStatus ComplaintStatus { get; set; } 
    }
}
