using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {


        //Navigation
        public IEnumerable<Complaint> Complaints { get; set; }
    }
}
