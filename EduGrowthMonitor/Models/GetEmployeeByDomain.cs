using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace EduGrowthMonitor.Models
{
    public class GetEmployeeByDomain
    {
        public List<EduProgressRecord>? EduProgressRecords { get; set; }
        public DateTime? SerchByDate { get; set; }
        public DateTime? SerchByDate2 { get; set; }
        public SelectList? EmployeeByDomain { get; set; }
        public string? EmpDomain { get; set; }
        public int? SearchId { get; set; }
        public int WeekelyHours { get; set; }
    }
}
