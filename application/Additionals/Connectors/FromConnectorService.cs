using application.Models;


namespace application.Additionals.Connectors.FromConnectors;

public class FromConnectorService
{
    private DatabaseContext _db;

    public FromConnectorService(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<SurveyModel?> TranslateFromDatabaseFirstOrDefault(int id)
    {
        throw new Exception("Not implemented for now");
    }

    public async Task<List<SurveyModel>> TranslateFromDatabaseAll()
    {
        throw new Exception("Not implemented for now");
    }
}