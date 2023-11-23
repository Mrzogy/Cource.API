using LearningHub.Core.DTO;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpPost]
        [Route("Serch")]
        public List<Serch> SearcheStudenCourse(Serch search)
        {
            return studentService.SearcheStudenCourse(search);
        }

        [HttpGet]
        [Route("Totla")]

        public List<TotalStudents> TotalStudentInEachCourse()
        {
            return studentService.TotalStudentInEachCourse();
        }
    }
}
