using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoulderLock.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string loginPass { get; set; }        
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        [ForeignKey("AccountEntity")]
        public int accountId { get; set; }
    }
}
