using Externalities.Modles;
using GenerativeAI;

namespace Externalities;

public class GeminiAi
{
    public async Task<AiResponsDto> getRespons(string query)
    {
        var ai = new GoogleAi(Environment.GetEnvironmentVariable("GOOGLE_AI_API_KEY"));
        var model = ai.CreateGenerativeModel("models/gemini-2.0-flash");
        var respons = await model.GenerateContentAsync(query);
        return new AiResponsDto
        {
            response = respons.Text,
        };
    }
}