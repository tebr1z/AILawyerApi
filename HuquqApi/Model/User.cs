using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HuquqApi.Model
{
    public class User : IdentityUser
    {
   

        public string FullName { get; set; }

        public string LastName { get; set; }
        public bool IsPremium { get; set; }
        public DateTime? PremiumExpirationDate { get; set; }
        public int RequestCount { get; set; }
        public int RequestCountTime { get; set; }

        public int MonthlyQuestionCount { get; set; }

        public DateTime LastQuestionDate { get; set; }
        public List<Chat> Chats { get; set; }
        public string? ResetPasswordOtp { get; set; }
        public DateTime? OtpExpiryTime { get; set; }

    }

}
