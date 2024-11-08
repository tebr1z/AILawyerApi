using HuquqApi.Dtos.UserDtos;
using HuquqApi.Model;
using HuquqApi.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin,MasterAdmin")]

[Route("api/admin")]
[ApiController]



public class AdminController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly HuquqDbContext _context;
    private readonly IEmailService _emailService;

    private readonly ISmsService _smsService;

    public AdminController(UserManager<User> userManager, HuquqDbContext context, IEmailService emailService, ISmsService smsService)
    {

        _userManager = userManager;
        _context = context;
        _emailService = emailService;
        _smsService = smsService;
    }


    [HttpGet("get-users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userManager.Users.Select(u => new
        {
            u.Id,
            u.UserName,
            u.LastName,
            u.FullName,
            u.Email,
            u.IsPremium,
            u.PremiumExpirationDate,
            u.RequestCount,
            u.EmailConfirmed,
            u.LockoutEnabled,
            u.LockoutEnd
            
        }).ToListAsync();

        return Ok(users);
    }
    [HttpGet("total-user-count")]
    public async Task<IActionResult> GetTotalUserCount()
    {
        var totalUserCount = await _userManager.Users.CountAsync();

        return Ok(new { totalUserCount });
    }
    [HttpPost("ban-user")]
    public async Task<IActionResult> BanUser([FromBody] UserBanDto banDto)
    {
        var user = await _userManager.FindByIdAsync(banDto.UserId);

        if (user == null)
        {
            return NotFound("Isfadeci Tapilmadi .");
        }
        if (user.LockoutEnabled == false)
        {
            return BadRequest(new { message = "Bu istifadəçi ban atmaq qadağandir" });
        }

        user.LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(banDto.BanDurationInMinutes);
        await _userManager.UpdateAsync(user);

        return Ok($"Isfadeci {banDto.BanDurationInMinutes} deqiqe  Blok oldu");
    }


    [HttpPost("unban-user/{userId}")]
    public async Task<IActionResult> UnbanUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User id tapilmadi");
        }


        user.LockoutEnd = null;
        await _userManager.UpdateAsync(user);

        return Ok("Istafdeci bani acildi");
    }




    [HttpGet("blocked-user-count")]
    public async Task<IActionResult> GetBlockedUserCount()
    {
        var blockedUserCount = await _userManager.Users
            .Where(u => u.LockoutEnd != null && u.LockoutEnd > DateTimeOffset.UtcNow)
            .CountAsync();

        return Ok(new { blockedUserCount });
    }

    [HttpPost]
    [Route("ApproveForm/{id}")]
    public async Task<IActionResult> ApproveForm(int id)
    {
        var form = await _context.contactForms.FindAsync(id);
        if (form == null)
        {
            return NotFound("Form not found.");
        }


        form.IsApproved = true;
        await _context.SaveChangesAsync();


        string body = string.Empty;
        using (StreamReader reader = new StreamReader("wwwroot/template/approveFormTemplate.html"))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{{FullName}}", form.FullName);
        body = body.Replace("{{PhoneNumber}}", form.PhoneNumber);

        _emailService.SendEmail(new List<string> { form.Email }, "Your Contact Form Has Been Approved", body);



        // Status mesajını əl ilə təyin et
        string status = "Müraciətiniz təsdiqləndi,tezliklə əlaqə saxlanılacaq.";

        // SMS göndərmə
        var smsResult = await _smsService.SendSmsAsync(form.PhoneNumber, form.FullName, form.Subject, status);

        if (!smsResult)
        {
            return StatusCode(200, "Forum Ugurla Təsdiq edildi email göndərildi. Lakin SMS göndərilmədi.");
        }
        return Ok("Forum Ugurla Təsdiq edildi. Email və Sms göndərildi");





    }


    [HttpGet("approved-forms")]
    public async Task<IActionResult> GetApprovedForms()
    {
        var approvedForms = await _context.contactForms
            .Where(f => f.IsApproved == true)
            .ToListAsync();

        return Ok(approvedForms);
    }
    [HttpGet("unapproved-forms")]
    public async Task<IActionResult> GetUnapprovedForms()
    {
        var unapprovedForms = await _context.contactForms
            .Where(f => f.IsApproved == false)
            .ToListAsync();

        return Ok(unapprovedForms);
    }



    [HttpGet("approved-forms-count")]
    public async Task<IActionResult> GetApprovedFormsCount()
    {
        var approvedFormsCount = await _context.contactForms
            .Where(f => f.IsApproved == true)
            .CountAsync();

        return Ok(new { approvedFormsCount });
    }

   
    [HttpGet("unapproved-forms-count")]
    public async Task<IActionResult> GetUnapprovedFormsCount()
    {
        var unapprovedFormsCount = await _context.contactForms
            .Where(f => f.IsApproved == false)
            .CountAsync();

        return Ok(new { unapprovedFormsCount });
    }

    [HttpGet]
    [Route("GetAllForms")]
    public async Task<IActionResult> GetAllForms()
    {
        var forms = await _context.contactForms.ToListAsync();
        return Ok(forms);
    }
    [HttpGet]
    [Route("GetAllFormsCount")]
    public async Task<IActionResult> GetAllFormsCount()
    {
        var forms = await _context.contactForms.ToListAsync();
        var response = new
        {
            TotalForms = forms.Count,

        };
        return Ok(response);
    }



    //İstifadəçiyə premium  verin
    [HttpPost("set-premium/{userId}")]
    public async Task<IActionResult> SetPremium(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("İstifadəçi tapılmadı.");
        }
        //Premium statusu verin və 30 günlük etibarlılıq müddəti təyin edin
        user.IsPremium = true;
        user.PremiumExpirationDate = DateTime.UtcNow.AddDays(30);
        user.RequestCount = int.MaxValue; //Premium istifadəçilər üçün limitsiz sorğular

        await _userManager.UpdateAsync(user);

        return Ok(new { message = "Kullanıcıya premium  verildi." });
    }

    //İstifadəçidən premium statusu silin
    [HttpPost("remove-premium/{userId}")]
    public async Task<IActionResult> RemovePremium(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("İstifadəçi tapılmadı.");
        }

        //Premium statusunu silin və sorğu limitini 10-a təyin edin
        user.IsPremium = false;
        user.PremiumExpirationDate = null;
        user.RequestCount = 10; // Premium deyilsə, maksimum 10 sorğu

        await _userManager.UpdateAsync(user);

        return Ok(new { message = "Premium statusu istifadəçidən silindi." });
    }



  
    [HttpPut]
    [Route("UpdateRequestCount")]
    public async Task<IActionResult> UpdateRequestCount([FromBody] int newRequestCount)
    {
        var requestCountSetting = _context.Settings.FirstOrDefault(s => s.Key == "RequestCount");

        if (requestCountSetting == null)
        {
            
            requestCountSetting = new Setting
            {
                Key = "RequestCount",
                Value = newRequestCount.ToString()
            };
            _context.Settings.Add(requestCountSetting);
        }
        else
        {
           
            requestCountSetting.Value = newRequestCount.ToString();
        }

        await _context.SaveChangesAsync();
        return Ok("RequestCount Yenilendi");
    }




   
    [HttpDelete("delete/{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { message = "istifadəçi Tapılmadı !" });
        }
        
        if (user.LockoutEnabled == false)
        {
            return BadRequest(new { message = "Bu istifadəçi silinə bilməz!." });
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return NoContent();
    }


}
