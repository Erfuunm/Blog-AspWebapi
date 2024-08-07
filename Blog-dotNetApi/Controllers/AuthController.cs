using Blog_dotNetApi.Cors.Dtos;
using Blog_dotNetApi.Cors.Entities;
using Blog_dotNetApi.Cors.Interfaces;
using Blog_dotNetApi.Cors.OtherObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Blog_dotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        //Init Interfaces and CTOR

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        // Get / Post / Put / Delete Methodes

        // Route For Seeding my roles to DB
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seerRoles = await _authService.SeedRolesAsync();

            return Ok(seerRoles);
        }


        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser([FromQuery] string token)
        {
           var username =  _authService.ExtractFirstName(token);

            DataDto dataDto = new DataDto();
            dataDto.UserName = username;

            var user = await _authService.UserDataAsync(dataDto);

            return Ok(user);
        }



   




        // Route -> Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authService.RegisterAsync(registerDto);

            if (registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }




        // Route -> Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
          {
            var loginResult = await _authService.LoginAsync(loginDto);

            

            if (loginResult.IsSucceed)
                return Ok(loginResult);

            return Unauthorized(loginResult);
        }




        // Route -> make user -> admin
        [HttpPost]
        [Route("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _authService.MakeAdminAsync(updatePermissionDto);

            if (operationResult.IsSucceed)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }




        // Route -> make user -> owner
        [HttpPost]
        [Route("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var operationResult = await _authService.MakeOwnerAsync(updatePermissionDto);

            if (operationResult.IsSucceed)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }



         [HttpGet("extractFirstName")]
        public IActionResult ExtractFirstName(string token)
        {
            try
            {
                // Split the token into parts
                var parts = token.Split('.');
                if (parts.Length != 3)
                {
                    return BadRequest("Invalid JWT token.");
                }

                // Decode the payload (the second part of the JWT)
                var payload = parts[1];
                var jsonBytes = Convert.FromBase64String(PadBase64(payload));
                var jsonString = Encoding.UTF8.GetString(jsonBytes);

                // Deserialize the JSON to a dynamic object
                var payloadData = JsonSerializer.Deserialize<JsonElement>(jsonString);

                // Extract FirstName from the payload data
                if (payloadData.TryGetProperty("FirstName", out JsonElement firstNameElement))
                {
                    return Ok(firstNameElement.GetString());
                }
                else
                {
                    return NotFound("FirstName not found in the token.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error extracting FirstName: {ex.Message}");
            }
        }

        private string PadBase64(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: return base64 + "==";
                case 3: return base64 + "=";
                default: return base64;
            }
        }


    }


}