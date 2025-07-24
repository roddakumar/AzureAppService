using Microsoft.AspNetCore.Mvc;

namespace AppService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MyDbContext _context;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Teacher> Get()
        {
            return _context.Teachers.ToList();
        }

        [HttpPost(Name = "InsertTeaccher")]
        public IActionResult Post([FromBody] TeacherCreateDto teacher)
        {
            var standard =  _context.Standards.Find(teacher.StandardId);
            if (standard == null)
                return NotFound($"Standard ID {teacher.StandardId} not found.");
            var data = new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                StandardId = teacher.StandardId,
            };
            _context.Teachers.Add(data);

            _context.SaveChanges();

            return Ok(_context.Teachers.ToList());
        }
    }
}
