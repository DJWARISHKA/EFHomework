using System.Collections.Generic;

namespace EFHomework.Entities
{
    public class Faculty
    {
        public Faculty()
        {
            Groups = new List<Group>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int StudentsCount { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}