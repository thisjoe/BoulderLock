using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoulderLock.Models
{
    public class GetUser
    {
        public int Id { get; set; }
        public int Acc_Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        //public string? Role { get; set; }
        public DateTime DateCreated { get; set; }
    }
}