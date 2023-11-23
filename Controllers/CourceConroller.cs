using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LearningHub.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CourceConroller : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourceConroller(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        [Route("DisplyCource")]
        public List<Cource> GitAllCource()
        {
            return courseService.GitAllCource();
        }

        [HttpPost]
        [Route("CreateCourse")]
        public void CreateCourse(Cource cource)
        {
            courseService.CreateCourse(cource);
        }

        [HttpGet]
        [Route("getByCourseId/{id}")]
        public Cource GetByCourseId(int id)
        {
            return courseService.GetByCourseId(id);
        }


        [HttpPut]
        [Route("UpdateCource")]
        public void UpdateCourse(Cource course)
        {
            courseService.UpdateCourse(course);
        }

        [HttpDelete]
        [Route("DeleteCource")]
        public void DeleteCourse(int id)
        {
            courseService.DeleteCourse(id);
        }

        [HttpGet]
        [Route("UserAndName")]
        public List<UserDTO> getuserRole()
        {
            return courseService.getuserRole();
        }
        [HttpPost]
        [Route("UploadImage")]
        public Cource UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Cource item = new Cource();
            item.Imagename = file.FileName;
            return item;

        }
        [HttpGet("weather/{city}")]
        public async Task<Weather> weather(string city)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=409d0e4d51f32cbcd7ce4f2dcb9f3e76\r\n");
                var stringResult = await response.Content.ReadAsStringAsync();
                var weatherResult = JsonConvert.DeserializeObject<Weather>(stringResult);
                return weatherResult;
            }
        }
    }

}

