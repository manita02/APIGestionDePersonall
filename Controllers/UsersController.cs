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
        private readonly  SQLiteConnection _db;
        
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            string localDb = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "localDb");
            _db = new SQLiteConnection(localDb);
            _db.CreateTable<UserEntity>();
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UserModel user)
        {
            var result = _db.Insert(new UserEntity()
            {
                Name = user.Name,
                Lastname = user.Lastname
            });
            return Ok(result > 0);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _db.Query<UserEntity>($"Select * from Users");
            if (users != null)
            {
                return Ok(users.Select(x=> new UserModel()
                {
                    Name = x.Name,
                    Lastname = x.Lastname
                }));
            }
            return NotFound();
        }

    }
}
