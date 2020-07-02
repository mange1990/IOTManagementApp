using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTManagementApp.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.ChangePassword = 1;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int ChangePassword { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
