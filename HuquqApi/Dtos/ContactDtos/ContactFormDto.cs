using System.ComponentModel.DataAnnotations;

namespace HuquqApi.Dtos.ContactDtos
{
    public class ContactFormDto
    {
        [Required]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Duzgun E-Poct adresi yazin!")]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }

}
