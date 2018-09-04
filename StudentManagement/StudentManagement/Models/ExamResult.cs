using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class ExamResult
    {
        public int ExamResultID { get; set; }

        public DateTime ExamDate { get; set; }

        public int Score { get; set; }

        // Dit zijn foreign key relaties
        // EF weet zelf welke IDs aan elkaar gekoppeld moeten worden
        public virtual Student Student { get; set; }

        // virtual is hier nodig om lazy loading te enablen
        public virtual Exam Exam { get; set; }

        [ForeignKey("Exam")]
        public int ExamID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
    }
}