using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWeb.Models;

public class LeaveTypeVm
{
    public int Id { get; set; }

    [Display(Name = "Leave Type Name")]
    [Required]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Default Number Of Days")]
    [Required]
    [Range(1, 25, ErrorMessage = "Please enter a valid number between 1 and 25")]
    public int DefaultDays { get; set; }
}