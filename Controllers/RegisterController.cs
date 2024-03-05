using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneatAPI.DataContext;
using SneatAPI.Entity.Register;
using SneatAPI.Model.Register;
using System;

namespace SneatAPI.Controllers
{
    [Route("api/register")]
    public class RegisterController : Controller
    {
        private readonly SneatContext _context;

        public RegisterController(SneatContext context)
        {
            _context = context;
        }

        [HttpGet("register")]
        public ActionResult<IEnumerable<RegisterEntity>> GetRegisteredUsers()
        {
            var registeredUsers = _context.RegisterEntities.ToList();
            return Ok(registeredUsers);
        }
        [HttpPost("signup")]
        public async Task<ActionResult<IEnumerable<RegisterEntity>>> Registration([FromBody]Register register)
        {

            if (register == null || string.IsNullOrEmpty(register.UserName) || string.IsNullOrEmpty(register.Email) || string.IsNullOrEmpty(register.Password))
            {
                return BadRequest("Please provide valid registration data");
            }

            // Check for duplicate email
            if (_context.RegisterEntities.Any(e => e.Email == register.Email))
            {
                return Conflict("Email already exists. Please use a different email.");
            }
            var data = new RegisterEntity()
            {
                UserName = register.UserName,
                Email = register.Email,
                Password = EncodePassword(register.Password)
            };

            _context.RegisterEntities.Add(data);
            await _context.SaveChangesAsync();

            // Get the list of registered entities after successful registration
            var registeredEntities = await _context.RegisterEntities.ToListAsync();

            return Ok(registeredEntities);
        }


        private string EncodePassword(string password)
        {
            // Use a secure password hashing algorithm instead of Base64 encoding
            // For example, you can use BCrypt.Net to hash the password
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        [HttpPost("login")]
        public async Task<ActionResult<loginEntity>> Login([FromBody] Login login)
        {
            var user = await _context.RegisterEntities.FirstOrDefaultAsync(check => check.Email == login.Email);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (!VerifyPassword(login.Password, user.Password))
            {
                return BadRequest("Invalid password");
            }

            // Check if the login details already exist in the LoginEntities table
            if (_context.loginEntities.Any(e => e.Email == login.Email && e.Password == user.Password))
            {
                var loginEntity = await _context.loginEntities.FirstOrDefaultAsync(e => e.Email == login.Email);

                if (loginEntity != null)
                {
                    //var username = user.UserName;
                    return Ok(new { Email = loginEntity.Email , username = user.UserName});
                }
            }
            else
            {
            var loginData = new loginEntity()
            {
                Email = user.Email,
                Password = user.Password
            };

            _context.loginEntities.Add(loginData);
            await _context.SaveChangesAsync();

                //return Ok(new { Email = loginEntity.Email });
                //return Ok("login!");
                return Ok(new { Email = loginData.Email, UserName = user.UserName });
            }

            return BadRequest("login failed");
        }


        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            // Use BCrypt.Net to verify the entered password against the stored hashed password
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedPassword);
        }
    }
}
