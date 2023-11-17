using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoulderLock.Data.Entities
{
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }
        [ForeignKey("UserEntity")]
        public int userId { get; set; }
        public virtual UserEntity User { get; set; }
        [ForeignKey("AccountEntity")]
        public int accountId { get; set; }
        public virtual AccountEntity Account { get; set;}
    }
}
