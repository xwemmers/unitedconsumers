using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name="Gebruikersnaam")]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.Password)]
        [Display(Name="Wachtwoord")]
        public string Password { get; set; }
    }
}