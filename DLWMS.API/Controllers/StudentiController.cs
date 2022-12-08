using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DLWMS.Repository;
using DLWMS.Servicee;
using DLWMS.Core;

namespace DLWMS.API.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentiController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return Ok(studentService.GetAll());
        }
    }
}
