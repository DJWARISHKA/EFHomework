using System.Collections.Generic;

namespace EFHomework.Entities
{
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int StudentsCount { get; set; }

        public ICollection<Student> Students { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}