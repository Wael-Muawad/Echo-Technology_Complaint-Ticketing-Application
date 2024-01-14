using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Complaints
{
    public class ComplaintCreateDto
    {
        private string userName;
        private string userNumber;
        private ComplaintStatus ComplaintStatus { get; set; } = ComplaintStatus.InProgress;



        [Required]
        public string FilePath { get; set; }

        [Required]
        public string ComplaintDetails { get; set; }

        [Required]
        public Priority Priority { get; set; } = Priority.Normal;

        
        public string GetUserName()
        {
            return userName;
        }

        public void SetUserName(string value)
        {
            userName = value;
        }

        public string GetUserNumber()
        {
            return userNumber;
        }

        public void SetUserNumber(string value)
        {
            userNumber = value;
        }
    }
}
