using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Demand : BaseEntity
    {
        public string DemandDetails { get; set; }

        public int ComplaintID { get; set; }


        //Navigations
        public Complaint Complaint { get; set; }
    }
}
