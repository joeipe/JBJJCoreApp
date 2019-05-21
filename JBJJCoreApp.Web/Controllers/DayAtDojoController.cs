using DayAtDojo.Data.Services;
using JBJJCoreApp.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JBJJCoreApp.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DayAtDojoController : ControllerBase
    {
        private DayAtDojoData _dayAtDojoData;

        public DayAtDojoController(DayAtDojoData dayAtDojoData)
        {
            _dayAtDojoData = dayAtDojoData;
        }

        #region Outcome

        [HttpGet]
        public ActionResult GetOutcome()
        {
            try
            {
                return Ok(_dayAtDojoData.GetOutcome());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetOutcomeById(int id)
        {
            try
            {
                var outcomeVM = _dayAtDojoData.GetOutcomeById(id);

                if (outcomeVM == null)
                {
                    return NotFound();
                }

                return Ok(outcomeVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddOutcome([FromBody]OutcomeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.AddOutcome(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateOutcome([FromBody]OutcomeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.UpdateOutcome(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOutcome(int id)
        {
            try
            {
                var outcomeVM = _dayAtDojoData.GetOutcomeById(id);
                if (outcomeVM == null)
                {
                    return NotFound();
                }

                _dayAtDojoData.DeleteOutcome(outcomeVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion Outcome

        #region Attendance

        [HttpGet]
        public ActionResult GetAttendance()
        {
            try
            {
                return Ok(_dayAtDojoData.GetAttendance());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetAttendanceById(int id)
        {
            try
            {
                var attendanceVM = _dayAtDojoData.GetAttendanceById(id);

                if (attendanceVM == null)
                {
                    return NotFound();
                }

                return Ok(attendanceVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetAttendanceWithGraphById(int id)
        {
            try
            {
                var attendanceVM = _dayAtDojoData.GetAttendanceWithGraphById(id);

                if (attendanceVM == null)
                {
                    return NotFound();
                }

                return Ok(attendanceVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddAttendance([FromBody]AttendanceViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.AddAttendance(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateAttendance([FromBody]AttendanceViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.UpdateAttendance(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAttendance(int id)
        {
            try
            {
                var attendanceVM = _dayAtDojoData.GetAttendanceById(id);
                if (attendanceVM == null)
                {
                    return NotFound();
                }

                _dayAtDojoData.DeleteAttendance(attendanceVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion Attendance

        #region SparringDetails

        [HttpGet]
        public ActionResult GetSparringDetails()
        {
            try
            {
                return Ok(_dayAtDojoData.GetSparringDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public ActionResult GetSparringDetailsWithGraph()
        {
            try
            {
                return Ok(_dayAtDojoData.GetSparringDetailsWithGraph());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetSparringDetailsById(int id)
        {
            try
            {
                var sparringDetailsVM = _dayAtDojoData.GetSparringDetailsById(id);

                if (sparringDetailsVM == null)
                {
                    return NotFound();
                }

                return Ok(sparringDetailsVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetSparringDetailsWithGraphById(int id)
        {
            try
            {
                var sparringDetailsVM = _dayAtDojoData.GetSparringDetailsWithGraphById(id);

                if (sparringDetailsVM == null)
                {
                    return NotFound();
                }

                return Ok(sparringDetailsVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddSparringDetails([FromBody]SparringDetailsViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.AddSparringDetails(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateSparringDetails([FromBody]SparringDetailsViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dayAtDojoData.UpdateSparringDetails(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSparringDetails(int id)
        {
            try
            {
                var sparringDetailsVM = _dayAtDojoData.GetSparringDetailsById(id);
                if (sparringDetailsVM == null)
                {
                    return NotFound();
                }

                _dayAtDojoData.DeleteSparringDetails(sparringDetailsVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion SparringDetails
    }
}