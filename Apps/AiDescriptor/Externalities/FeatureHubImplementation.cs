using FeatureHubSDK;

namespace DefaultNamespace;

public class FeatureHubImplementation
{
    public async Task<EnabledAIFeature> GetAiFeature()
    {
        var config = new EdgeFeatureHubConfig("http://featurehub:8085", Environment.GetEnvironmentVariable("FEATUREHUB_TOKEN"));
        var fh = await config.NewContext().Build();
        var aiDescriptor = fh["AiDescriptor"].IsEnabled;
        if (aiDescriptor)
        {
            return new EnabledAIFeature
            {
                AiDescriptor = aiDescriptor
            };
        }
        else
        {
            return null;
        }
    }
}