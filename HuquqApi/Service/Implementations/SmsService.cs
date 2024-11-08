using HuquqApi.Service.Interfaces;
using Newtonsoft.Json;
using System.Text;

public class SmsService : ISmsService
{
    private readonly HttpClient _httpClient;

    public SmsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // SMS gönderim metodu, yalnız gerekli parametreleri alır.
    public async Task<bool> SendSmsAsync(string phoneNumber, string name, string subject, string status)
    {
        // Telefon numarasını formatla
        phoneNumber = FormatPhoneNumber(phoneNumber);

        // SMS API tarafından beklenen parametre formatı
        var smsRequest = new
        {
            sender_name = "SMS Plus",
            message_template_id = 160,
            mobile_numbers = new string[] { phoneNumber },
            first_parameters = new string[] { name },
            second_parameters = new string[] { subject },
            third_parameters = new string[] { status }
        };

        var requestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://smsplus.az/api/sms/send"),
            Headers = { { "Authorization", "Bearer 24|3WPiiT9IoasD3lUZ97R5WM40pxiXtswfFEXnf6UnTTTT" } },
            Content = new StringContent(JsonConvert.SerializeObject(smsRequest), Encoding.UTF8, "application/json")
        };

        try
        {
            var response = await _httpClient.SendAsync(requestMessage);
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"SMS API Response: {responseBody}");

            var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

            if (result.success == true && result.code == "100")
            {
                Console.WriteLine("SMS gönderildi.");
                return true;
            }
            else
            {
                Console.WriteLine($"SMS Xətası: {result.code} - {result.message}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SMS xetasi: {ex.Message}");
            return false;
        }
    }

    private string FormatPhoneNumber(string phoneNumber)
    {
        phoneNumber = phoneNumber.Trim();

        if (phoneNumber.StartsWith("+994"))
        {
            phoneNumber = phoneNumber.Substring(4);
        }
        else if (phoneNumber.StartsWith("9940"))
        {
            phoneNumber = phoneNumber.Substring(4);
        }
        else if (phoneNumber.StartsWith("994"))
        {
            phoneNumber = phoneNumber.Substring(3);
        }
        else if (phoneNumber.StartsWith("0"))
        {
            phoneNumber = phoneNumber.Substring(1);
        }

        return $"994{phoneNumber}";
    }
}
