namespace HuquqApi.Model
{
    public class ContactForm
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsApproved { get; set; } = false; 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }


}
