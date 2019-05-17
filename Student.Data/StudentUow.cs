using SharedKernel.Data;
using SharedKernel.Interfaces;
using Student.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Data
{
    public class StudentUow : IUow
    {
        private StudentContext _studentContext;
        public StudentUow(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public GenericRepository<Grade> GradesRepo { get { return new GenericRepository<Grade>(_studentContext); } }
        public GenericRepository<Person> PeopleRepo { get { return new GenericRepository<Person>(_studentContext); } }
        public void Dispose()
        {
            _studentContext.Dispose();
        }

        public void Save()
        {
            _studentContext.SaveChanges();
        }
    }
}
