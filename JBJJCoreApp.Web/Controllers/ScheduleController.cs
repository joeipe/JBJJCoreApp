using JBJJCoreApp.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Data.Services;
using System;

namespace JBJJCoreApp.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private ScheduleData _scheduleData;

        public ScheduleController(ScheduleData scheduleData)
        {
            _scheduleData = scheduleData;
        }

        #region ClassType

        [HttpGet]
        public ActionResult GetClassType()
        {
            try
            {
                return Ok(_scheduleData.GetClassType());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetClassTypeById(int id)
        {
            try
            {
                var classTypeVM = _scheduleData.GetClassTypeById(id);

                if (classTypeVM == null)
                {
                    return NotFound();
                }

                return Ok(classTypeVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddClassType([FromBody] ClassTypeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.AddClassType(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateClassType([FromBody] ClassTypeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.UpdateClassType(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClassType(int id)
        {
            try
            {
                var classTypeVM = _scheduleData.GetClassTypeById(id);
                if (classTypeVM == null)
                {
                    return NotFound();
                }

                _scheduleData.DeleteClassType(classTypeVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion ClassType

        #region TimeTable

        [HttpGet]
        public ActionResult GetTimeTable()
        {
            try
            {
                return Ok(_scheduleData.GetTimeTable());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        public ActionResult GetTimeTableWithGraph()
        {
            try
            {
                return Ok(_scheduleData.GetTimeTableWithGraph());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetTimeTableById(int id)
        {
            try
            {
                var timeTable = _scheduleData.GetTimeTableById(id);

                if (timeTable == null)
                {
                    return NotFound();
                }

                return Ok(timeTable);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetTimeTableWithClassTypeById(int id)
        {
            try
            {
                var timeTable = _scheduleData.GetTimeTableWithClassTypeById(id);

                if (timeTable == null)
                {
                    return NotFound();
                }

                return Ok(timeTable);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddTimeTable([FromBody] TimeTableViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.AddTimeTable(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateTimeTable([FromBody] TimeTableViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _scheduleData.UpdateTimeTable(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTimeTable(int id)
        {
            try
            {
                var timeTableVM = _scheduleData.GetTimeTableById(id);
                if (timeTableVM == null)
                {
                    return NotFound();
                }

                _scheduleData.DeleteTimeTable(timeTableVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        #endregion TimeTable
    }
}