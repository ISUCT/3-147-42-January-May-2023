using application.Models;

namespace application.Additionals.Connectors.FromConnectors;

public class ToConnectorService
{
    private DatabaseContext _db;

    public ToConnectorService(DatabaseContext db)
    {
        _db = db;
    }

    public async Task TranslateToDatabaseAsync(SurveyModel surveyModel)
    {
        
    }

    public async Task<SurveyModel> UpdateToDatabaseAsync(SurveyModel surveyModel)
    {
        throw new Exception("Not implemented for now");
    }

    public async Task<bool> DeleteToDatabaseAsync(int id)
    {
        throw new Exception("Not implemented for now");
    }
}