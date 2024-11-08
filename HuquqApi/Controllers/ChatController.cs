using HuquqApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ChatService _chatService;
    private readonly HuquqDbContext _dbContext; 
    private readonly string _pdfContent;
    public ChatController(UserManager<User> userManager, ChatService chatService, HuquqDbContext dbContext)
    {
        _userManager = userManager;
        _chatService = chatService;
        _dbContext = dbContext;
   
    }


    private async Task<bool> CanUserMakeRequest(User user)
    {
        //Premium  müddəti bitibsə, premium  statusunu silin
        if (user.IsPremium && user.PremiumExpirationDate < DateTime.UtcNow)
        {
            user.IsPremium = false;
            user.PremiumExpirationDate = null;
            user.RequestCount = 10; // Premium deyilsə, maksimum 10 sorğu
            await _userManager.UpdateAsync(user);
        }

        // Premium istifadəçilər limitsiz sorğu verə bilər
        if (user.IsPremium)
        {
            return true;
        }

        // Əgər Premium  deyilsə, qalan sorğu istək yoxlayın
        if (user.RequestCount > 0)
        {
            user.RequestCount--; // Qalan sorğu istək  azaldın

            await _userManager.UpdateAsync(user);
            return true;
        }

        // Tələb etmək hüququ yoxdur
        return false;
    }



    [HttpPost("send-message")]
    public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
    {
  
        var jwtUserId = User.FindFirst("id")?.Value;
        if (string.IsNullOrEmpty(jwtUserId))
        {
            return Unauthorized(new { message = "JWT-dən istifadəçi ID-sini əldə etmək alınmadı." });
        }

      
        var user = await _userManager.FindByIdAsync(jwtUserId);
        if (user == null)
        {
            return BadRequest(new { message = "İstifadəçi tapılmadı." });
        }

    
        if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTimeOffset.UtcNow)
        {
            return Unauthorized(new
            {
                message = "İstifadəçi qadağan edildi.",
                banEndTime = user.LockoutEnd.Value,
                remainingBanTime = $"{(user.LockoutEnd.Value - DateTimeOffset.UtcNow).TotalMinutes:F2} Dəqiqə"
            });
        }

        await _userManager.ResetAccessFailedCountAsync(user);

     
        if (_chatService == null || _dbContext == null)
        {
            return StatusCode(500, "_chatService Server Xetası ");
        }

       
        if (request == null || string.IsNullOrEmpty(request.Message))
        {
            return StatusCode(102, new { message = "Etibarsız sorğu. sorğu və mesaj tələb olunur." });
        }

      
        if (!user.EmailConfirmed)
        {
            return BadRequest(new { message = "E-poçt ünvanınızı təsdiqləyin." });
        }


        if (!await CanUserMakeRequest(user))
        {
            return StatusCode(101, new { message = "Gündəlik sorğu limitinizə çatdınız. 24 saat ərzində yenidən cəhd edə bilərsiniz, biz həmişə buradayıq 😊" });
        }


        Chat chat = await _dbContext.Chats
            .FirstOrDefaultAsync(c => c.Id == request.ChatId && c.UserId == jwtUserId);

        if (chat == null)
        {
            chat = new Chat
            {
                UserId = user.Id,
                Title = request.Message.Length > 10 ? request.Message[..10] : request.Message,
                CreatedAt = DateTime.UtcNow,
                Messages = new List<Message>()
            };

            _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync(); 
        }

        var userMessage = new Message
        {
            ContentUser = request.Message,
            SentAt = DateTime.UtcNow,
            UpdateTime = DateTime.UtcNow,
            ChatId = chat.Id
        };

        _dbContext.Messages.Add(userMessage);
        await _dbContext.SaveChangesAsync(); 

        try
        {
         
            string response = await _chatService.SendMessageToChatGPTAsync(request.Message, null);
            if (string.IsNullOrEmpty(response))
            {
                return StatusCode(103, "Üzür istəyirik ChatBot cavab vermədi. Daha sonra təkrar yoxlayın");
            }

            userMessage.ContentBot = response;
            _dbContext.Messages.Update(userMessage);
            await _dbContext.SaveChangesAsync(); 

            return Ok(new
            {
                chatId = chat.Id,
                userMessage = userMessage.ContentUser,
                botResponse = userMessage.ContentBot
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Hata: {ex.Message}");
        }
    }







    [HttpGet("get-chats")]
    public async Task<IActionResult> GetChats()
    {
        var jwtUserId = User.FindFirst("id")?.Value;

        if (string.IsNullOrEmpty(jwtUserId))
        {
            return Unauthorized(new { message = "JWT-dən istifadəçi ID-sini əldə etmək mümkün olmadı" });
        }

      
        var chats = await _dbContext.Chats
            .Where(c => c.UserId == jwtUserId)
            .OrderBy(c => c.CreatedAt)
            .Select(c => new { c.Id, c.Title, c.CreatedAt })
            .ToListAsync();

        if (chats == null || !chats.Any())
        {
            return NotFound("İstifadəçi üçün heç bir söhbət tapılmadı.");
        }

        return Ok(chats);
    }















    [HttpPost("create-chat")]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatRequest request)
    {
        var jwtUserId = User.FindFirst("id")?.Value;
        if (string.IsNullOrEmpty(jwtUserId))
        {
            return Unauthorized(new { message = "stifadəçi identifikatoru JWT-dən əldə edilə bilmədi." });
        }

     
        if (string.IsNullOrEmpty(request.Title))
        {
            return BadRequest(new { message = "Etibarsız sorğu. 'title' mütləqdir." });
        }

   
        var user = await _userManager.FindByIdAsync(jwtUserId);
        if (user == null)
        {
            return BadRequest(new { message = "İstifadəçi tapılmadı." });
        }

        var chat = new Chat
        {
            UserId = user.Id,
            Title = request.Title,
            CreatedAt = DateTime.UtcNow,
            UpdateTime = DateTime.UtcNow,
            Messages = new List<Message>()
        };

        _dbContext.Chats.Add(chat);
        await _dbContext.SaveChangesAsync();

        return Ok(new { chatId = chat.Id });
    }




    [HttpGet("get-messages/{chatId}")]
    public async Task<IActionResult> GetMessages(int chatId)
    {
        var chat = await _dbContext.Chats
            .Include(c => c.Messages)
            .FirstOrDefaultAsync(c => c.Id == chatId);

        if (chat == null)
        {
            return NotFound("Chat Tapılmadı.");
        }

        var messages = chat.Messages
            .Select(m => new
            {
                ContentUser = m.ContentUser,
                ContentBot = m.ContentBot,
                SentAt = m.SentAt,
                UpdateTime = m.UpdateTime
            })
            .OrderBy(m => m.SentAt)
            .ToList();

        return Ok(messages);
    }


    public class CreateChatRequest
    {

        public string Title { get; set; }
    }





}




public class SendMessageRequest
{
    public string Message { get; set; }
  
    public int? ChatId { get; set; } 
}
