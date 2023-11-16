using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoulderLock.Models.User
{
    public class UserRegister
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Acc_Id { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(4)]
        public string? Username { get; set; }

        [Required]
        public string? Role { get; set; }

        [Required]
        [MinLength(4)]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}