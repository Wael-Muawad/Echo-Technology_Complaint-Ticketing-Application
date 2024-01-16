using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Complaint : BaseEntity
    {
        public string FilePath { get; set; }

        public string ComplaintDetails { get; set; }
        public Priority Priority { get; set; } = Priority.Normal;
        public ComplaintStatus ComplaintStatus { get; set; } = ComplaintStatus.InProgress;

        public int UserID { get; set; }

        //navigations
        public IEnumerable<Demand> Demands { get; set; }
        public AppUser User { get; set; }

    }
}
