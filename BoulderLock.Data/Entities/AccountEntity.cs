using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderLock.Data.Entities
{
    public class AccountEntity
    {
        [Key]
        public int accountId { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
