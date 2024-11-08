namespace HuquqApi.Model
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string ?IpAddress { get; set; }
        public string ?MacAddress { get; set; }
        public string? Path { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsSuccessful { get; set; } // Başarılı veya başarısız isteği belirtir
        public string ?ErrorMessage { get; set; } // Hata mesajı
        public string ?StackTrace { get; set; } // Hatanın stack trace'i
    }


}
