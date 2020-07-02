using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTManagementApp.Models
{
    public class Device
    {
        public string Description { get; set; }
        public bool IsConnected { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
