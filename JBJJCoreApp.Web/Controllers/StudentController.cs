using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBJJCoreApp.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Data.Services;

namespace JBJJCoreApp.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentData _studentData;
        public StudentController(StudentData studentData)
        {
            _studentData = studentData;
        }

        #region Grade
        [HttpGet]
        public ActionResult GetGrade()
        {
            try
            {
                return Ok(_studentData.GetGrade());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetGradeById(int id)
        {
            try
            {
                var gradeVM = _studentData.GetGradeById(id);

                if (gradeVM == null)
                {
                    return NotFound();
                }

                return Ok(gradeVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddGrade([FromBody]GradeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.AddGrade(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdateGrade([FromBody]GradeViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.UpdateGrade(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGrade(int id)
        {
            try
            {
                var gradeVM = _studentData.GetGradeById(id);
                if (gradeVM == null)
                {
                    return NotFound();
                }

                _studentData.DeleteGrade(gradeVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        #endregion

        #region Person
        [HttpGet]
        public ActionResult GetPerson()
        {
            try
            {
                return Ok(_studentData.GetPerson());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetPersonById(int id)
        {
            try
            {
                var person = _studentData.GetPersonById(id);

                if (person == null)
                {
                    return NotFound();
                }

                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetPersonWithGradeById(int id)
        {
            try
            {
                var student = _studentData.GetPersonWithGradeById(id);

                if (student == null)
                {
                    return NotFound();
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult AddPerson([FromBody]PersonViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.AddPerson(value);

                return Created("", value);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public ActionResult UpdatePerson([FromBody]PersonViewModel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentData.UpdatePerson(value);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            try
            {
                var personVM = _studentData.GetPersonById(id);
                if (personVM == null)
                {
                    return NotFound();
                }

                _studentData.DeletePerson(personVM);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        #endregion
    }
}