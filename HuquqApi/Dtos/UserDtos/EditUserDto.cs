namespace HuquqApi.Dtos.UserDtos
{
    public class EditUserDto
    {
        public string? FullName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; } // Şifre güncellemeleri için
    }
}
