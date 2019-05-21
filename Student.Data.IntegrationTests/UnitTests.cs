using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Student.Data.Services;
using Student.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Student.Data.IntegrationTests
{
    [TestClass]
    public class UnitTests
    {
        private List<Grade> _gradesInMemory;
        private List<Person> _peopleInMemory;
        private DbContextOptions<StudentContext> _options;
        private StudentData _studentData;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<StudentContext>()
                .UseInMemoryDatabase().Options;
            var dbContext = new StudentContext(_options);
            SeedInMemoryStore();
            _studentData = new StudentData(new StudentUow(dbContext));
        }

        #region Grade

        [TestMethod]
        public void Can_GetGrade()
        {
            // Arrange
            // Act
            var result = _studentData.GetGrade();

            // Assert
            Assert.AreEqual(_gradesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetGradeById()
        {
            // Arrange
            // Act
            var result = _studentData.GetGradeById(1);

            // Assert
            Assert.AreEqual(_gradesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddGrade()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateGrade()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteGrade()
        {
            // Arrange
            // Act
            // Assert
        }

        #endregion Grade

        #region Person

        [TestMethod]
        public void Can_GetPerson()
        {
            // Arrange
            // Act
            var result = _studentData.GetPerson();

            // Assert
            Assert.AreEqual(_peopleInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetPersonById()
        {
            // Arrange
            // Act
            var result = _studentData.GetPersonById(1);

            // Assert
            Assert.AreEqual(_peopleInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_GetPersonWithGradeById()
        {
            // Arrange
            // Act
            var result = _studentData.GetPersonWithGradeById(1);

            // Assert
            Assert.AreEqual(_peopleInMemory.Where(x => x.Id == 1).First().Id, result.Id);
            Assert.AreEqual(_peopleInMemory.Where(x => x.Id == 1).First().Grade.Id, result.Grade.Id);
        }

        [TestMethod]
        public void Can_AddPerson()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdatePerson()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeletePerson()
        {
            // Arrange
            // Act
            // Assert
        }

        #endregion Person

        private void SeedInMemoryStore()
        {
            var grade1 = new Grade() { Id = 1, Name = "White" };
            var grade2 = new Grade() { Id = 2, Name = "Blue" };
            var person1 = new Person() { Id = 1, FirstName = "TestFName1", LastName = "TestLName1", GradeId = 1, Stripe = 1, Grade = grade1 };
            var person2 = new Person() { Id = 2, FirstName = "TestFName2", LastName = "TestLName1", GradeId = 2, Stripe = 4, Grade = grade2 };
            _gradesInMemory = new List<Grade>() { grade1, grade2 };
            _peopleInMemory = new List<Person>() { person1, person2 };

            using (var context = new StudentContext(_options))
            {
                if (!context.Grades.Any())
                {
                    context.Grades.AddRange(
                        _gradesInMemory
                    );
                }

                if (!context.People.Any())
                {
                    context.People.AddRange(
                        _peopleInMemory
                    );
                }
                context.SaveChanges();
            }
        }
    }
}