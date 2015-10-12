using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEngine45.Models.Community;

namespace CEngine45.Models.Base
{
    public class Content
    {
        public Content()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public UserProfile CreatedBy { get; set; }
    }
}
