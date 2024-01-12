using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Complaint : BaseEntity
    {

        public string UserName { get; set; }
        public string UserNumber { get; set; }

        public string IDFilePDFPath { get; set; }

        public string ComplaintDetails { get; set; }
        public bool IsApproved { get; set; }


        //navigations
        public IEnumerable<Demand> Demands { get; set; }

    }
}
