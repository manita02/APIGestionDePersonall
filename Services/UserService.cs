using System.Reflection;
using ApiDevBP.Entities;
using ApiDevBP.Models;
using Microsoft.Extensions.Options;
using SQLite;

public class UserService
{
    private readonly SQLiteConnection _db;
    private readonly ILogger<UserService> _logger;

    private readonly DbOptions _dbOptions;

    public UserService(IOptions<DbOptions> dbOptions, ILogger<UserService> logger) 
    {
        //_db = db;
        //_db.CreateTable<UserEntity>();
        
        _logger = logger;

        _dbOptions = dbOptions.Value;

        //var localDb = Path.Combine(dbOptions.Value.ConnectionString, "localDb.db");
        //_db = new SQLiteConnection(localDb);

        logger.LogWarning("string de conexion: "+_dbOptions.ConnectionString);
        _db = new SQLiteConnection(_dbOptions.ConnectionString);
        _db.CreateTable<UserEntity>();
    }

    public bool SaveUser(UserModel user)
    {
        try
        {
            var result = _db.Insert(new UserEntity()
            {
                    Name = user.Name,
                    Lastname = user.Lastname
            });
            _logger.LogInformation("Usuario guardado con éxito");
            return result > 0;

        }
        catch (Exception ex)
        {
            _logger.LogError("Error al guardar un usuario");
            throw new Exception($"Error al guardar el usuario: {ex.Message}", ex);
        }
    }

    public IEnumerable<UserModel> GetUsers()
    {
        try
        {
            var users = _db.Query<UserEntity>("Select * from Users");
            _logger.LogInformation("Se han obtenido todos los usuarios que se encuentran en la base de datos");
            return users.Select(x => new UserModel
            {
                Name = x.Name,
                Lastname = x.Lastname
            });
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al obtener los usuarios");
            throw new Exception($"Error al obtener los usuarios en la base de datos: {ex.Message}", ex);
        }
    }

    public bool UpdateUser(int id, UserModel updatedUser)
    {
        try
        {
            var existingUser = _db.Find<UserEntity>(id);
            if (existingUser == null)
            {
                _logger.LogError("No se ha encontrado el usuario con el id: "+ id);
                return false; // Usuario no encontrado
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Lastname = updatedUser.Lastname;

            var result = _db.Update(existingUser);
            _logger.LogInformation("Usuario actualizado");
            return result > 0;
        }
        catch (Exception ex)
        {
             _logger.LogError("No se pudo actualizar el usuario con el id: "+ id);
            throw new Exception($"Error al actualizar el usuario con ID {id}: {ex.Message}", ex);
        }
    }

    public bool DeleteUser(int id)
    {
        try
        {
            var userToDelete = _db.Find<UserEntity>(id);
            if (userToDelete == null)
            {
                 _logger.LogError("No se ha encontrado el usuario con el id: "+ id);
                return false; // Usuario no encontrado
            }

            var result = _db.Delete(userToDelete);
             _logger.LogInformation("Usuario con el id: "+ id + " eliminado con exito!!");
            return result > 0;
        }
        catch (Exception ex)
        {
             _logger.LogError("No se pudo eliminar el usuario con el id: "+ id);
            throw new Exception($"Error al eliminar el usuario con ID {id}: {ex.Message}", ex);
        }
    }

    public UserModel SearchUser(int userId)
    {
        try
        {
            var user = _db.Find<UserEntity>(userId);
            if (user != null)
            {
                 _logger.LogInformation("Usuario encontrado");
                return new UserModel
                {
                    Name = user.Name,
                    Lastname = user.Lastname
                };
            }
            _logger.LogError("Error al obtener usuario por ID {UserId}", userId);
            return null; // Usuario no encontrado
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener usuario por ID {UserId}", userId);
            throw new Exception($"Error al obtener el usuario por ID {userId}: {ex.Message}", ex);
        }
    }
}