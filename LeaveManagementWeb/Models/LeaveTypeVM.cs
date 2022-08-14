using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWeb.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Default Number Of Days")]
        public int DefaultDays { get; set; }
    }
}