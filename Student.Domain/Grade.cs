using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domain
{
    public class Grade : EntityBase
    {
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }
}
