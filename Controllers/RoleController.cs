using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public List<Role> GitAllRole()
        {
            return this.roleService.GitAllRole();
        }
        [HttpPost]
        public void CreateRole(Role role)
        {
            this.roleService.CreateRole(role);
        }
        [HttpPut]
        public void UpdateRole(Role role)
        {
            this.roleService.UpdateRole(role);
        }
        [HttpDelete]
        public void DeleteRole(int id)
        {
            this.roleService.DeleteRole(id);
        }
    }
}
