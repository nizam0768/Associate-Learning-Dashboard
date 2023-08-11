using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduGrowthMonitor.Models
{
    public class EduProgressRecord
    {
        public int Id { get; set; }
        [Display(Name = "Employee ID")]
        public int Emp_ID { get; set; }
        public string Domain { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Task { get; set; } = null!;
        [Display(Name ="Details")]
        public string Deatils { get; set; }
        public int Hours { get; set; }
        public string? Comments { get; set; }
    }
}
