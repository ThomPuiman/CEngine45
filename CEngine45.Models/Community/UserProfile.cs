﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEngine45.Models.Community
{
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(45)]
        public string UserName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public DateTime MemberSince { get; set; }
    }
}
