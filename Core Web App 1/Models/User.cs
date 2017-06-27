using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MingGuApps.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter user name.")]
        [Display(Name = "User Name")]
        [StringLength(30)]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(3)]
        public string password { get; set; }
        public bool isActive { get; set; }
    }
}
