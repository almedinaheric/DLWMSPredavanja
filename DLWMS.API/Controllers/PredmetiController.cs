using DLWMS.Core;
using DLWMS.Servicee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLWMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetiController : ControllerBase
    {
        private readonly IPredmetService predmetService;
        private readonly IStudentService studentService;
        private readonly ILogger<PredmetiController> logger;

        public PredmetiController(IPredmetService predmetService,
                                  IStudentService studentService,
                                  ILogger<PredmetiController> logger)
        {
            this.predmetService = predmetService;
            this.studentService = studentService;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Predmet> Get()
        {
            logger.Log(LogLevel.Information, "NEKO JE ZAHTJEVAO SVE PODATKE");
            return predmetService.GetAll();
        }

        [HttpPost]
        public IActionResult Post(Predmet newPredmet)
        {
            logger.Log(LogLevel.Information, "NEKO JE ZAHTJEVAO DODAVANJE");
            studentService.Save(new Student()
            {
                BrojIndeksa = "200",
                Ime = "ime",
                Prezime = "prezime"
            });
            predmetService.Save(newPredmet);
            return Ok(newPredmet);    
        }
    }
}
