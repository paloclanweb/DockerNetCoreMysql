namespace Domain
{
    public class Student
    {
        public int ID { get; set; }

        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Department Department { get; set; } 
    }
}