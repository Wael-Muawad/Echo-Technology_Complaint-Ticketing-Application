﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Users
{
    public class UserReadDto
    { 
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
