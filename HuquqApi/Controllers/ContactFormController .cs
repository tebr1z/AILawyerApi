using HuquqApi.Dtos.ContactDtos;
using HuquqApi.Model;
using HuquqApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContactFormController : ControllerBase
{
    private readonly HuquqDbContext _context;
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;

    public ContactFormController(HuquqDbContext context, IEmailService emailService, ISmsService smsService)
    {
        _context = context;
        _emailService = emailService;
        _smsService = smsService;
    }

    [HttpPost]
    [Route("SubmitForm")]
    public async Task<IActionResult> SubmitForm([FromBody] ContactFormDto formDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (string.IsNullOrEmpty(formDto.Email) && string.IsNullOrEmpty(formDto.PhoneNumber))
        {
            return BadRequest("Xaish olunur duzgun telfon nomresi ve ya email daxil edin");
        }

        var form = new ContactForm
        {
            FullName = formDto.FullName,
            Email = formDto.Email,
            PhoneNumber = formDto.PhoneNumber,
            Subject = formDto.Subject,
            Message = formDto.Message,
            IsApproved = false,
            CreatedAt = DateTime.UtcNow
        };

        _context.contactForms.Add(form);
        await _context.SaveChangesAsync();

        // E-posta gönderme
        string body = string.Empty;
        using (StreamReader reader = new StreamReader("wwwroot/template/receivedFormTemplate.html"))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{{FullName}}", form.FullName);
        body = body.Replace("{{PhoneNumber}}", form.PhoneNumber ?? "Yazmayib");

        _emailService.SendEmail(new List<string> { form.Email }, "We have received your message", body);

        if (!string.IsNullOrEmpty(form.PhoneNumber))
        {
            string status = "Muracietinize baxilir"; 

            var isSmsSent = await _smsService.SendSmsAsync(form.PhoneNumber, form.FullName, form.Subject, status);

            if (!isSmsSent)
            {
                return StatusCode(200, "Forum uğurla göndərildi. Lakin SMS göndərilmədi, ");
            }
        }

        return Ok(new{form});
    }
}
