namespace HuquqApi.Model
{
   
        public class Message
        {
            public int Id { get; set; }
            public string? ContentUser { get; set; }
            public string? ContentBot { get; set; }
            public DateTime SentAt { get; set; }
            public DateTime UpdateTime { get; set; }
            public int ChatId { get; set; }
            public Chat Chat { get; set; }
        }
    

}
