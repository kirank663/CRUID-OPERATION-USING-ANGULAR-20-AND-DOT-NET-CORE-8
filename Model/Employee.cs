namespace EMPLOYEE_CRUID_API.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Title { get; set; } = "";
        public bool IsActive { get; set; } = true;
        public System.DateTime InsertedOn { get; set; }
        public System.DateTime? ModifiedOn { get; set; }
    }
}
