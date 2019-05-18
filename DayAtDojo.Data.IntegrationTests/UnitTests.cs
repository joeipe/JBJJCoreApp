using DayAtDojo.Data.Services;
using DayAtDojo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayAtDojo.Data.IntegrationTests
{
    [TestClass]
    public class UnitTests
    {
        private List<Outcome> _outcomesInMemory;
        private List<Attendance> _attendanceInMemory;
        private List<SparringDetails> _sparringDetailsInMemory;
        private List<TimeTableClassAttended> _timeTableClassAttendedInMemory;
        private List<PersonSparringPartner> _personSparringPartnerInMemory;
        private DbContextOptions<DayAtDojoContext> _options;
        private DbContextOptions<ReferenceScheduleContext> _referenceScheduleOptions;
        private DbContextOptions<ReferenceStudentContext> _referenceStudentOptions;
        private DayAtDojoData _dayAtDojoData;

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<DayAtDojoContext>()
                .UseInMemoryDatabase().Options;
            var dbContext = new DayAtDojoContext(_options);
            _referenceScheduleOptions = new DbContextOptionsBuilder<ReferenceScheduleContext>()
                .UseInMemoryDatabase().Options;
            var referenceScheduleContext = new ReferenceScheduleContext(_referenceScheduleOptions);
            _referenceStudentOptions = new DbContextOptionsBuilder<ReferenceStudentContext>()
                .UseInMemoryDatabase().Options;
            var referenceStudentContext = new ReferenceStudentContext(_referenceStudentOptions);
            SeedInMemoryStore();
            _dayAtDojoData = new DayAtDojoData(new DayAtDojoUow(dbContext, referenceScheduleContext, referenceStudentContext));
        }

        #region Outcome
        [TestMethod]
        public void Can_GetOutcome()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetOutcome();

            // Assert
            Assert.AreEqual(_outcomesInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetOutcomeById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetOutcomeById(1);

            // Assert
            Assert.AreEqual(_outcomesInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddOutcome()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateOutcome()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteOutcome()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        #region Attendance
        [TestMethod]
        public void Can_GetAttendance()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetAttendance();

            // Assert
            Assert.AreEqual(_attendanceInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetAttendanceById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetAttendanceById(1);

            // Assert
            Assert.AreEqual(_attendanceInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_GetAttendanceWithGraphById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetAttendanceWithGraphById(1);

            // Assert
            Assert.AreEqual(_attendanceInMemory.Where(x => x.Id == 1).First().Id, result.Id);
            Assert.AreEqual(_timeTableClassAttendedInMemory.Where(x => x.Id == 1).First().ClassType, result.TimeTableClassAttended.ClassType);
        }

        [TestMethod]
        public void Can_AddAttendance()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateAttendance()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteAttendance()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        #region SparringDetails
        [TestMethod]
        public void Can_GetSparringDetails()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetSparringDetails();

            // Assert
            Assert.AreEqual(_sparringDetailsInMemory.Count(), result.Count());
        }

        [TestMethod]
        public void Can_GetSparringDetailsWithGraph()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetSparringDetailsWithGraph();

            // Assert
            Assert.AreEqual(_sparringDetailsInMemory.Count(), result.Count());
            //Assert.AreEqual(_attendanceInMemory.Where(a => a.Id == 1).First().Id, result.Where(r => r.Id == 1).First().Attendance.Id);
            Assert.AreEqual(_outcomesInMemory.Where(o => o.Id == 2).First().Id, result.Where(r => r.Id == 2).First().Outcome.Id);
            Assert.AreEqual(_personSparringPartnerInMemory.Where(o => o.Id == 2).First().Id, result.Where(r => r.Id == 2).First().PersonSparringPartner.Id);
        }

        [TestMethod]
        public void Can_GetSparringDetailsById()
        {
            // Arrange
            // Act
            var result = _dayAtDojoData.GetSparringDetailsById(1);

            // Assert
            Assert.AreEqual(_sparringDetailsInMemory.Where(x => x.Id == 1).First().Id, result.Id);
        }

        [TestMethod]
        public void Can_AddSparringDetails()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_UpdateSparringDetails()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void Can_DeleteSparringDetails()
        {
            // Arrange
            // Act
            // Assert
        }
        #endregion

        private void SeedInMemoryStore()
        {
            var outcome1 = new Outcome() { Id = 1, Name = "Win" };
            var outcome2 = new Outcome() { Id = 2, Name = "Loss" };
            var attendance1 = new Attendance() { Id = 1, TimeTableId = 1, AttendedOn = DateTime.Now, TechniqueOfTheDay = "Something" }; //TimeTable = null
            var sparringDetails1 = new SparringDetails() { Id = 1, AttendanceId = 1, PersonId = 1, OutcomeId = 1, TechniqueUsed = "rear naked choke", Outcome = outcome1 };
            var sparringDetails2 = new SparringDetails() { Id = 2, AttendanceId = 1, PersonId = 2, OutcomeId = 2, TechniqueUsed = "Passing the guard", Outcome = outcome2 };
            var timeTable1 = new TimeTableClassAttended() { Id = 1, DayofWeek = "Monday", StartTimeHr = 6, StartTimeMin = 45, EndTimeHr = 7, EndTimeMin = 45, ClassType = "BJJ Gi All Levels" };
            var person1 = new PersonSparringPartner() { Id = 1, FullName = "Peppe Impala", Stripe = 0, Grade = "Purple" };
            var person2 = new PersonSparringPartner() { Id = 2, FullName = "Leonard Correa", Stripe = 2, Grade = "Purple" };
            _outcomesInMemory = new List<Outcome>() { outcome1, outcome2 };
            _attendanceInMemory = new List<Attendance>() { attendance1 };
            _sparringDetailsInMemory = new List<SparringDetails>() { sparringDetails1, sparringDetails2 };
            _timeTableClassAttendedInMemory = new List<TimeTableClassAttended>() { timeTable1 };
            _personSparringPartnerInMemory = new List<PersonSparringPartner>() { person1, person2 };

            using (var context = new DayAtDojoContext(_options))
            {
                if (!context.Outcomes.Any())
                {
                    context.Outcomes.AddRange(
                        _outcomesInMemory
                    );
                }

                if (!context.Attendance.Any())
                {
                    context.Attendance.AddRange(
                        _attendanceInMemory
                    );
                }

                if (!context.SparringDetails.Any())
                {
                    context.SparringDetails.AddRange(
                        _sparringDetailsInMemory
                    );
                }
                context.SaveChanges();
            }

            using (var context = new ReferenceScheduleContext(_referenceScheduleOptions))
            {
                if (!context.TimeTableClassAttended.Any())
                {
                    context.TimeTableClassAttended.AddRange(
                        _timeTableClassAttendedInMemory
                    );
                }
                context.SaveChanges();
            }

            using (var context = new ReferenceStudentContext(_referenceStudentOptions))
            {
                if (!context.PersonSparringPartners.Any())
                {
                    context.PersonSparringPartners.AddRange(
                        _personSparringPartnerInMemory
                    );
                }
                context.SaveChanges();
            }
        }
    }
}
