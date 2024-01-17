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
    
    /// <summary>
    /// Obtiene un usuario por su ID.
    /// </summary>
    /// <param name="userId">ID del usuario.</param>
    /// <returns>Datos del usuario.</returns>
    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(UserModel), 200)]
    [ProducesResponseType(404)]
    public IActionResult SearchUser(int userId)
    {
        var user = _userService.SearchUser(userId);
        if (user != null)
        {
            return Ok(user);
        }
        return NotFound($"Usuario con ID {userId} no encontrado.");
    }

    /// <summary>
    /// Guarda un nuevo usuario.
    /// </summary>
    /// <param name="user">Datos del nuevo usuario.</param>
    /// <returns>Resultado de la operación.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public IActionResult SaveUser(UserModel user)
    {
        var result = _userService.SaveUser(user);
        return Ok(result);
    }

   
    /// <summary>
    /// Obtiene todos los usuarios.
    /// </summary>
    /// <returns>Lista de usuarios.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserModel>), 200)]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    /// <summary>
    /// Actualiza un usuario existente.
    /// </summary>
    /// <param name="id">ID del usuario a actualizar.</param>
    /// <param name="updatedUser">Datos actualizados del usuario.</param>
    /// <returns>Resultado de la operación.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(404)]
    public IActionResult UpdateUser(int id, UserModel updatedUser)
    {
        var result = _userService.UpdateUser(id, updatedUser);
        if(result == false){
            return NotFound($"Usuario con ID {id} no encontrado para poder ser actualizado.");
        }
        return Ok(result);
    }

    /// <summary>
    /// Elimina un usuario por su ID.
    /// </summary>
    /// <param name="id">ID del usuario a eliminar.</param>
    /// <returns>Resultado de la operación.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    [ProducesResponseType(404)]
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
