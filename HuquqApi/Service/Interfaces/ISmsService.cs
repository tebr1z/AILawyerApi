namespace HuquqApi.Service.Interfaces
{
    public interface ISmsService
    {
        Task<bool> SendSmsAsync(string phoneNumber, string name, string subject, string status);
     
    }
}
