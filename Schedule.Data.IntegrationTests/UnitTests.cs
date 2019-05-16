using JBJJCoreApp.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Data.Services;
using Schedule.Domain;
using Schedule.Domain.Enums;
using SharedKernel.Data;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Data.IntegrationTests
{
    [TestClass]
    public class UnitTests
    {
        private List<ClassType> _classTypesInMemory;
        private List<TimeTable> _timeTablesInMemory;
        private DbContextOptions<ScheduleContext> _options;
        private ScheduleData _scheduleData;

        [TestInitialize]
        public void Setup()
        {
            //_options = new DbContextOptionsBuilder<ScheduleContext>()
            //    .UseSqlServer("Server=.;Database=JBJJCoreDB;Trusted_Connection=True;").Options;

            _options = new DbContextOptionsBuilder<ScheduleContext>()
                .UseInMemoryDatabase().Options;
            var dbContext = new ScheduleContext(_options);
            SeedInMemoryStore();
            _scheduleData = new ScheduleData(new GenericRepository<ClassType>(dbContext), new GenericRepository<TimeTable>(dbContext));
        }

        #region ClassType
        [TestMethod]
        public void Can_GetClassType()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetClassType();

            // Assert
            Assert.AreEqual(_classTypesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetClassTypeById()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetClassTypeById(1);

            // Assert
            Assert.AreEqual(_classTypesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddClassType()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateClassType()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteClassType()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        #region TimeTable
        [TestMethod]
        public void Can_GetTimeTable()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetTimeTable();

            // Assert
            Assert.AreEqual(_timeTablesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetTimeTableById()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetClassTypeById(1);

            // Assert
            Assert.AreEqual(_timeTablesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_GetTimeTableWithClassTypeById()
        {
            // Arrange
            // Act
            var result = _scheduleData.GetTimeTableWithClassTypeById(1);

            // Assert
            Assert.AreEqual(_timeTablesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
            Assert.AreEqual(_timeTablesInMemory.Where(x => x.Id == 1).First().ClassType.Id, result.ClassType.Id);
        }

        [TestMethod]
        public void Can_AddTimeTable()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateTimeTable()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteTimeTable()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        private void SeedInMemoryStore()
        {
            var classType1 = new ClassType() { Id = 1, Name = "Test1" };
            var classType2 = new ClassType() { Id = 2, Name = "Test2" };
            var timeTable1 = new TimeTable() { Id = 1, DayofWeek = DayofWeek.Monday, StartTimeHr = 18, StartTimeMin = 30, EndTimeHr = 19, EndTimeMin = 30, ClassTypeId = 1, ClassType = classType1 };
            var timeTable2 = new TimeTable() { Id = 2, DayofWeek = DayofWeek.Monday, StartTimeHr = 19, StartTimeMin = 30, EndTimeHr = 20, EndTimeMin = 30, ClassTypeId = 2, ClassType = classType2 };
            _classTypesInMemory = new List<ClassType>() { classType1, classType2 };
            _timeTablesInMemory = new List<TimeTable>() { timeTable1, timeTable2 };

            using (var context = new ScheduleContext(_options))
            {
                if (!context.ClassTypes.Any())
                {
                    context.ClassTypes.AddRange(
                        _classTypesInMemory
                    );
                }

                if (!context.TimeTables.Any())
                {
                    context.TimeTables.AddRange(
                        _timeTablesInMemory
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
