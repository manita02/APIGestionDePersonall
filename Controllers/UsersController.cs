using ApiDevBP.Entities;
using ApiDevBP.Models;
using Microsoft.AspNetCore.Mvc;
using SQLite;
using System.Reflection;

namespace ApiDevBP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        //private readonly  SQLiteConnection _db;
        
        //private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, UserService userService)
        {
            //_logger = logger;
            //string localDb = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "localDb");
           // _db = new SQLiteConnection(localDb);
            //_db.CreateTable<UserEntity>();
            _userService = userService;

        }

    [HttpGet("{userId}")]
    public IActionResult SearchUser(int userId)
    {
        var user = _userService.SearchUser(userId);
        if (user != null)
        {
            return Ok(user);
        }
        return NotFound($"Usuario con ID {userId} no encontrado.");
    }

    [HttpPost]
    public IActionResult SaveUser(UserModel user)
    {
        var result = _userService.SaveUser(user);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserModel updatedUser)
    {
        var result = _userService.UpdateUser(id, updatedUser);
        if(result == false){
            return NotFound($"Usuario con ID {id} no encontrado para poder ser actualizado.");
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = _userService.DeleteUser(id);
        if(result == false){
            return NotFound($"Usuario con ID {id} no encontrado para poder ser eliminado.");
        }
        return Ok(result);
    }
}
}
