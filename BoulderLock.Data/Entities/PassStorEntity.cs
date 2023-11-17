using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderLock.Data.Entities
{
    public class PassStorEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Owner")]
        public int userId { get; set; }
        public virtual UserEntity Owner { get; set; }
        [Required]
        public string webSite { get; set; }
        [Required]
        public string webPassword { get; set; }
        public string webType {  get; set; }
    }
}
