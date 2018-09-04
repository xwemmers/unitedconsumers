using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Exam
    {
        public int ExamID { get; set; }
            
        [StringLength(10)]        
        public string Code { get; set; }

        [StringLength(50)]
        public string Description { get; set; }
    }
}