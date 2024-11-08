using HuquqApi.Dtos.UserDtos;
using HuquqApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HuquqApi.Controllers
{
    [Authorize(Roles = "MasterAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

      
        [HttpGet("get-all-users")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.AsNoTracking().ToListAsync();

            var userWithRoles = new List<object>();

            foreach (var user in users)
            {
             
                var roles = await _userManager.GetRolesAsync(user);
                userWithRoles.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.FullName,
                    user.LastName,
                    user.IsPremium,
                    user.PremiumExpirationDate,
                    user.RequestCount,
                    user.RequestCountTime,
                    user.MonthlyQuestionCount,
                    user.LastQuestionDate,
                    user.ResetPasswordOtp,
                    user.OtpExpiryTime,
                    Roles = roles
                });
            }

            return Ok(userWithRoles);
        }



        [HttpGet("get-user/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var userInfo = new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.FullName,
                user.LastName,
                user.IsPremium,
                user.PremiumExpirationDate,
                user.RequestCount,
                user.RequestCountTime,
                user.MonthlyQuestionCount,
                user.LastQuestionDate,
                user.ResetPasswordOtp,
                user.OtpExpiryTime,
                Roles = roles
            };

            return Ok(userInfo);
        }






        [HttpGet("get-admins")]
        public async Task<ActionResult> GetAdmins()
        {
            var users = await _userManager.Users
                                          .AsNoTracking() 
                                          .ToListAsync();

            var adminUsers = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

               
                if (roles.Contains("Admin") || roles.Contains("MasterAdmin"))
                {
                    adminUsers.Add(new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.FullName,
                        user.LastName,
                        user.IsPremium,
                        user.PremiumExpirationDate,
                        user.RequestCount,
                        user.RequestCountTime,
                        user.MonthlyQuestionCount,
                        user.LastQuestionDate,
                        user.ResetPasswordOtp,
                        user.OtpExpiryTime,
                        Roles = roles
                    });
                }
            }

            return Ok(adminUsers);
        }



        [HttpPost("grant-admin-status/{userId}")]
        public async Task<IActionResult> GrantAdminStatus(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin"))
            {
                var result = await _userManager.AddToRoleAsync(user, "Admin");
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                
                if (roles.Contains("User"))
                {
                    var removeUserRoleResult = await _userManager.RemoveFromRoleAsync(user, "User");
                    if (!removeUserRoleResult.Succeeded)
                    {
                        return BadRequest(removeUserRoleResult.Errors);
                    }
                }
            }

            return Ok($"{user.UserName} is now an Admin and User role removed if existed.");
        }




        [HttpPost("remove-admin-status/{userId}")]
        public async Task<IActionResult> RemoveAdminStatus(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var roles = await _userManager.GetRolesAsync(user);

         
            if (roles.Contains("Admin"))
            {
                var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }

            return Ok($"{user.UserName} is no longer an Admin.");
        }




        [HttpPost("update-user/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UserUpdateDto userUpdateDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

        
            user.FullName = userUpdateDto.FullName ?? user.FullName;
            user.LastName = userUpdateDto.LastName ?? user.LastName;
            user.IsPremium = userUpdateDto.IsPremium;
            user.PremiumExpirationDate = userUpdateDto.PremiumExpirationDate ?? user.PremiumExpirationDate;
            user.RequestCount = userUpdateDto.RequestCount;
            user.RequestCountTime = userUpdateDto.RequestCountTime;
            user.MonthlyQuestionCount = userUpdateDto.MonthlyQuestionCount;
            user.LastQuestionDate = userUpdateDto.LastQuestionDate ?? user.LastQuestionDate;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User updated successfully");
        }




       
    
    }

    
   
}
