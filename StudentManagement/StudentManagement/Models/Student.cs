using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht!")]
        [StringLength(20, ErrorMessage = "Max 20 tekens!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht!")]
        [StringLength(56)]
        public string Lastname { get; set; }
    }
}

