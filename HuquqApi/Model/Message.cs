namespace HuquqApi.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Role { get; set; } 
        public DateTime SentAt { get; set; }
        public DateTime UpdateTime { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }

}
