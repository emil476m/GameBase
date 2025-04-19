using infrastructur.Interfaces;

namespace infrastruvtur.Implementation;

public class SeartchRepositoryString: ISearchRepository<string,string>
{
    public Task<IEnumerable<string>> QuerySearch(string query)
    {
        throw new NotImplementedException();
    }
}