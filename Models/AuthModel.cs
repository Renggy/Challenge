using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Models
{
    public class AuthModel
    {
        [Key]
        public int id_user { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public int id_role { get; set; }
    }
}
