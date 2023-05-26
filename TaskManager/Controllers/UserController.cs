using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetAll()
        {
             
            UserModel userModel = new UserModel();
            userModel.Id = 1; 
               
            userModel.Name = "Test";
            userModel.Email = "email@test.com"; 

            List<UserModel> users = new List<UserModel>();

            users.Add(userModel);

            return Ok(users);
        }
    }
}
