using Domain.Enums;
using Microsoft.AspNetCore.Http;
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
        private int userID;
        private string filePath;
        private ComplaintStatus ComplaintStatus { get; set; } = ComplaintStatus.InProgress;

        [Required]
        public string ComplaintDetails { get; set; }

        [Required]
        public Priority Priority { get; set; } = Priority.Normal;

        public IFormFile File { get; set; }


        public string GetFilePath()
        {
            return filePath;
        }
        public void SetFilePath(string value)
        {
            filePath = value;
        }

        public int GetUserID()
        {
            return userID;
        }
        public void SetUserID(int value)
        {
            userID = value;
        }
    }
}
