using DefaultNamespace;
using Externalities;
using Externalities.Modles;

namespace Service;

public class AIService
{
    private readonly GeminiAi _geminiAi;
    private FeatureHubImplementation _fhi;
    public AIService(GeminiAi geminiAi, FeatureHubImplementation fhi)
    {
        _geminiAi = geminiAi;
        _fhi = fhi;
    }

    public async Task<AiResponsDto> getRespons(string query)
    {
        var feature = await _fhi.GetAiFeature();
        if (feature.AiDescriptor)
        {
            var respons = await _geminiAi.getRespons(query);
            return respons;
        }
        return null;
    }
}