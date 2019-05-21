using SharedKernel;
using System.Collections.Generic;

namespace Student.Domain
{
    public class Grade : EntityBase
    {
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }
}