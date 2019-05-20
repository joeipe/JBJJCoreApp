using JBJJCoreApp.Web.ViewModels;
using Student.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Data.Services
{
    public class StudentData
    {
        private StudentUow _studentUow;

        public StudentData(StudentUow studentUow)
        {
            _studentUow = studentUow;
        }

        #region Grade
        public IList<GradeViewModel> GetGrade()
        {
            var gradesData = _studentUow.GradesRepo.GetAll();
            var gradesVM = ObjectMapper.Mapper.Map<IList<GradeViewModel>>(gradesData);
            return gradesVM;
        }

        public GradeViewModel GetGradeById(int id)
        {
            var gradeData = _studentUow.GradesRepo.GetById(id);
            var gradeVM = ObjectMapper.Mapper.Map<GradeViewModel>(gradeData);
            return gradeVM;
        }

        public void AddGrade(GradeViewModel value)
        {
            var gradeData = ObjectMapper.Mapper.Map<Grade>(value);
            _studentUow.GradesRepo.Add<Grade>(gradeData);
            _studentUow.Save();
        }

        public void UpdateGrade(GradeViewModel value)
        {
            var gradeData = ObjectMapper.Mapper.Map<Grade>(value);
            _studentUow.GradesRepo.Edit<Grade>(gradeData);
            _studentUow.Save();
        }

        public void DeleteGrade(GradeViewModel value)
        {
            var gradeData = ObjectMapper.Mapper.Map<Grade>(value);
            _studentUow.GradesRepo.Delete(gradeData);
            _studentUow.Save();
        }
        #endregion

        #region Person
        public IList<PersonViewModel> GetPerson()
        {
            var personsData = _studentUow.PeopleRepo.GetAll();
            var personsVM = ObjectMapper.Mapper.Map<IList<PersonViewModel>>(personsData);
            return personsVM;
        }

        public PersonViewModel GetPersonById(int id)
        {
            var personData = _studentUow.PeopleRepo.GetById(id);
            var personVM = ObjectMapper.Mapper.Map<PersonViewModel>(personData);
            return personVM;
        }

        public PersonViewModel GetPersonWithGradeById(int id)
        {
            var personData = _studentUow.PeopleRepo
                .SearchForInclude
                (
                    t => t.Id == id,
                    i => i.Grade
                )
                .FirstOrDefault();
            var personVM = ObjectMapper.Mapper.Map<PersonViewModel>(personData);
            return personVM;
        }

        public void AddPerson(PersonViewModel value)
        {
            var personData = ObjectMapper.Mapper.Map<Person>(value);
            _studentUow.PeopleRepo.Add<Person>(personData);
            _studentUow.Save();
        }

        public void UpdatePerson(PersonViewModel value)
        {
            var personData = ObjectMapper.Mapper.Map<Person>(value);
            _studentUow.PeopleRepo.Edit<Person>(personData);
            _studentUow.Save();
        }

        public void DeletePerson(PersonViewModel value)
        {
            var personData = ObjectMapper.Mapper.Map<Person>(value);
            _studentUow.PeopleRepo.Delete(personData);
            _studentUow.Save();
        }
        #endregion
    }
}
