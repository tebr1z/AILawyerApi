namespace HuquqApi.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string FullName { get; set; }
        public string LastName { get; set; }
        public bool IsPremium { get; set; }
        public DateTime? PremiumExpirationDate { get; set; }
        public int RequestCount { get; set; }
        public int RequestCountTime { get; set; }
        public int MonthlyQuestionCount { get; set; }
        public DateTime? LastQuestionDate { get; set; }
    }
}
