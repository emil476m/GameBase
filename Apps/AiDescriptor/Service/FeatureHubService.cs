using DefaultNamespace;

namespace Service;

public class FeatureHubService
{
    private FeatureHubImplementation _fhi;
    public FeatureHubService(FeatureHubImplementation fhi)
    {
        _fhi = fhi;
    }

    public async Task<EnabledAIFeature> getFeatures()
    {
        var response = await _fhi.GetAiFeature();
        return response;
    }
}