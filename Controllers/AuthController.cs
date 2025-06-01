using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        connection.Open();

        var query = "SELECT COUNT(*) FROM users WHERE LoginName = @username AND Password = @password";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@username", request.Username);
        command.Parameters.AddWithValue("@password", request.Password);

        int count = (int)command.ExecuteScalar();

        if (count == 1)
        {
            return Ok(new { message = "Login exitoso" });
        }
        else
        {
            return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
        }
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
