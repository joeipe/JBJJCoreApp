using DayAtDojo.Domain;
using JBJJCoreApp.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DayAtDojo.Data.Services
{
    public class DayAtDojoData
    {
        private DayAtDojoUow _dayAtDojoUow;

        public DayAtDojoData(DayAtDojoUow dayAtDojoUow)
        {
            _dayAtDojoUow = dayAtDojoUow;
        }

        #region Outcome

        public IList<OutcomeViewModel> GetOutcome()
        {
            var outcomesData = _dayAtDojoUow.OutcomesRepo.GetAll();
            var outcomesVM = ObjectMapper.Mapper.Map<IList<OutcomeViewModel>>(outcomesData);
            return outcomesVM;
        }

        public OutcomeViewModel GetOutcomeById(int id)
        {
            var outcomeData = _dayAtDojoUow.OutcomesRepo.GetById(id);
            var outcomeVM = ObjectMapper.Mapper.Map<OutcomeViewModel>(outcomeData);
            return outcomeVM;
        }

        public void AddOutcome(OutcomeViewModel value)
        {
            var outcomeData = ObjectMapper.Mapper.Map<Outcome>(value);
            _dayAtDojoUow.OutcomesRepo.Add<Outcome>(outcomeData);
            _dayAtDojoUow.Save();
        }

        public void UpdateOutcome(OutcomeViewModel value)
        {
            var outcomeData = ObjectMapper.Mapper.Map<Outcome>(value);
            _dayAtDojoUow.OutcomesRepo.Edit<Outcome>(outcomeData);
            _dayAtDojoUow.Save();
        }

        public void DeleteOutcome(OutcomeViewModel value)
        {
            var outcomeData = ObjectMapper.Mapper.Map<Outcome>(value);
            _dayAtDojoUow.OutcomesRepo.Delete(outcomeData);
            _dayAtDojoUow.Save();
        }

        #endregion Outcome

        #region Attendance

        public IList<AttendanceViewModel> GetAttendance()
        {
            var attendancesData = _dayAtDojoUow.AttendanceRepo.GetAll();
            var attendancesVM = ObjectMapper.Mapper.Map<IList<AttendanceViewModel>>(attendancesData);
            return attendancesVM;
        }

        public IList<AttendanceViewModel> GetAttendanceWithTimeTableGraph()
        {
            var attendancesData = _dayAtDojoUow.AttendanceRepo.GetAll();
            foreach (var item in attendancesData)
            {
                item.TimeTableClassAttended = _dayAtDojoUow.TimeTableClassAttendedRepo.GetById(item.TimeTableId);
            }
            var attendancesVM = ObjectMapper.Mapper.Map<IList<AttendanceViewModel>>(attendancesData);
            return attendancesVM;
        }

        public AttendanceViewModel GetAttendanceById(int id)
        {
            var attendanceData = _dayAtDojoUow.AttendanceRepo.GetById(id);
            var attendanceVM = ObjectMapper.Mapper.Map<AttendanceViewModel>(attendanceData);
            return attendanceVM;
        }

        public AttendanceDetailedViewModel GetAttendanceWithGraphById(int id)
        {
            var attendanceData = _dayAtDojoUow.AttendanceRepo.SearchForInclude
                (
                    a => a.Id == id,
                    source => source
                        .Include(x => x.SparringDetails)
                        .ThenInclude(x => x.Outcome)
                ).FirstOrDefault();
            attendanceData.TimeTableClassAttended = _dayAtDojoUow.TimeTableClassAttendedRepo.GetById(attendanceData.TimeTableId);
            foreach (var item in attendanceData.SparringDetails)
            {
                item.PersonSparringPartner = _dayAtDojoUow.PersonSparringPartnersRepo.GetById(item.PersonId);
            }
            var attendanceVM = ObjectMapper.Mapper.Map<AttendanceDetailedViewModel>(attendanceData);
            return attendanceVM;
        }

        public void AddAttendance(AttendanceViewModel value)
        {
            var attendanceData = ObjectMapper.Mapper.Map<Attendance>(value);
            _dayAtDojoUow.AttendanceRepo.Add<Attendance>(attendanceData);
            _dayAtDojoUow.Save();
        }

        public void UpdateAttendance(AttendanceViewModel value)
        {
            var attendanceData = ObjectMapper.Mapper.Map<Attendance>(value);
            _dayAtDojoUow.AttendanceRepo.Edit<Attendance>(attendanceData);
            _dayAtDojoUow.Save();
        }

        public void DeleteAttendance(AttendanceViewModel value)
        {
            var attendanceData = ObjectMapper.Mapper.Map<Attendance>(value);
            _dayAtDojoUow.AttendanceRepo.Delete(attendanceData);
            _dayAtDojoUow.Save();
        }

        #endregion Attendance

        #region SparringDetails

        public IList<SparringDetailsViewModel> GetSparringDetails()
        {
            var sparringDetailssData = _dayAtDojoUow.SparringDetailsRepo.GetAll();
            var sparringDetailssVM = ObjectMapper.Mapper.Map<IList<SparringDetailsViewModel>>(sparringDetailssData);
            return sparringDetailssVM;
        }

        public IList<SparringDetailsViewModel> GetSparringDetailsWithGraph()
        {
            var sparringDetailssData = _dayAtDojoUow.SparringDetailsRepo.SearchForInclude
                (
                    s => s.Id != 0,
                    source => source
                        .Include(x => x.Attendance)
                        .Include(x => x.Outcome)
                );

            //Person
            foreach (var item in sparringDetailssData)
            {
                item.PersonSparringPartner = _dayAtDojoUow.PersonSparringPartnersRepo.GetById(item.PersonId);
            }

            var sparringDetailssVM = ObjectMapper.Mapper.Map<IList<SparringDetailsViewModel>>(sparringDetailssData);
            return sparringDetailssVM;
        }

        public SparringDetailsViewModel GetSparringDetailsById(int id)
        {
            var sparringDetailsData = _dayAtDojoUow.SparringDetailsRepo.GetById(id);
            var sparringDetailsVM = ObjectMapper.Mapper.Map<SparringDetailsViewModel>(sparringDetailsData);
            return sparringDetailsVM;
        }

        public SparringDetailsViewModel GetSparringDetailsWithGraphById(int id)
        {
            var sparringDetailsData = _dayAtDojoUow.SparringDetailsRepo.SearchForInclude
                (
                    s => s.Id == id,
                    source => source
                        .Include(x => x.Attendance)
                        .Include(x => x.Outcome)
                ).FirstOrDefault();

            //Person
            sparringDetailsData.PersonSparringPartner = _dayAtDojoUow.PersonSparringPartnersRepo.GetById(sparringDetailsData.PersonId);

            var sparringDetailsVM = ObjectMapper.Mapper.Map<SparringDetailsViewModel>(sparringDetailsData);
            return sparringDetailsVM;
        }

        public void AddSparringDetails(SparringDetailsViewModel value)
        {
            var sparringDetailsData = ObjectMapper.Mapper.Map<SparringDetails>(value);
            _dayAtDojoUow.SparringDetailsRepo.Add<SparringDetails>(sparringDetailsData);
            _dayAtDojoUow.Save();
        }

        public void UpdateSparringDetails(SparringDetailsViewModel value)
        {
            var sparringDetailsData = ObjectMapper.Mapper.Map<SparringDetails>(value);
            _dayAtDojoUow.SparringDetailsRepo.Edit<SparringDetails>(sparringDetailsData);
            _dayAtDojoUow.Save();
        }

        public void DeleteSparringDetails(SparringDetailsViewModel value)
        {
            var sparringDetailsData = ObjectMapper.Mapper.Map<SparringDetails>(value);
            _dayAtDojoUow.SparringDetailsRepo.Delete(sparringDetailsData);
            _dayAtDojoUow.Save();
        }

        #endregion SparringDetails
    }
}