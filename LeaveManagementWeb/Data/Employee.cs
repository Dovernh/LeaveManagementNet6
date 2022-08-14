using Microsoft.AspNetCore.Identity;

namespace LeaveManagementWeb.Data
{
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

        public Employee(string firstName, string lastName, string taxId, DateTime dateOfBirth, DateTime dateJoined)
        {
            FirstName = firstName;
            LastName = lastName;
            TaxId = taxId;
            DateOfBirth = dateOfBirth;
            DateJoined = dateJoined;
        }
    }
}