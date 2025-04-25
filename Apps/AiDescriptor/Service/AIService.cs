using Externalities;
using Externalities.Modles;

namespace Service;

public class AIService
{
    private readonly GeminiAi _geminiAi;
    public AIService(GeminiAi geminiAi)
    {
        _geminiAi = geminiAi;
    }

    public async Task<AiResponsDto> getRespons(string query)
    {
        var respons = await _geminiAi.getRespons(query);
        return respons;
    }
}