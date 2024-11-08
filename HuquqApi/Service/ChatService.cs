using System.Text;
using System.Text.Json;

public class ChatService
{
    private readonly string _apiKey;

    public ChatService()
    {
    }

    public async Task<string> SendMessageToChatGPTAsync(string question, string pdfContent)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
          
            var prompt = $"PDF məzmunu: {pdfContent}\n\n" +
                         $"Sual: {question}\n\n" +
                         "Əgər sual PDF məzmununda varsa, yalnız bu PDF məzmununa əsaslanaraq cavab ver. " +
                         "Əgər sual PDF məzmununda yoxdursa,Pdf məzmunu yoxdur və ya məlumat yoxdur yazma, lakin hüquqi bir sual isə və mürəkkəb deyilsə, öz biliklərinlə cavab ver.:" +
                         "Əgər sual nə PDF məzmunu ilə, nə də hüquqi mövzularla əlaqəli deyilsə, bu mesajı qaytar və Pdf məzmunu yoxdur məlumat yoxdur yazma yalnız bu mesajı qaytar: 'Bu sual hüquqi mövzularla əlaqəli deyil Və ya Daha mürəkəbbdir. Məsləhət görərik`ki . Ətraflı məlumat üçün hüquq məsləhətçisinə müraciət edin. Hüquqi məsəlləri  üçün linkə kilik edin ' " +
                         "Bütün cavabları yalnız Azərbaycan dilində yaz.";

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                max_tokens = 1000
            };

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions",
                new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonDocument.Parse(responseData);
                var responseText = result.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                if (string.IsNullOrEmpty(responseText))
                {
                    return "Bu suala cavab verməkdə çətinlik çəkirik. Sizi bir hüquq məsləhətçisinə yönləndirək.";
                }

                return responseText.Trim();
            }
            else
            {
                var errorData = await response.Content.ReadAsStringAsync();
                return $"ChatGPT API sorğusu uğursuz oldu. Xəta: {response.StatusCode}, Ətraflı məlumat: {errorData}";
            }
        }
    }
}
