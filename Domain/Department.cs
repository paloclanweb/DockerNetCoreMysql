using System.Collections.Generic;

namespace Domain
{
    public class Department
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}