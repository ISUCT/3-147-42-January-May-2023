using System.Text.Json;
using application.Additionals;
using application.Additionals.Connectors.FromConnectors;
using application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace application.Controllers;

public class APIController : Controller
{
    private DatabaseContext _db;
    private FromConnectorService _fromDb;
    private ToConnectorService _toDb;
    private JsonSerializerOptions _options;

    public APIController(DatabaseContext db, FromConnectorService fromDb, ToConnectorService toDb)
    {
        _db = db;
        _fromDb = fromDb;
        _toDb = toDb;
        _options.Converters.Add(new SurveySerializer());
    }

    public async Task<IActionResult> GetSurvey(int? id)
    {
        if (id is not null)
        {
            var surveyModel = await _fromDb.TranslateFromDatabaseFirstOrDefault(id.Value);
            if (surveyModel is null)
            {
                return NotFound();
            }
            
            return Json(surveyModel, _options);
        }

        var surveyModels = await _fromDb.TranslateFromDatabaseAll();

        return Json(surveyModels, _options);
    }

    public async Task<IActionResult> AddSurvey()
    {
        var surveyModel = await HttpContext.Request.ReadFromJsonAsync<SurveyModel>(_options);
        
        if (surveyModel is not null)
        {
            await _toDb.TranslateToDatabaseAsync(surveyModel);
            return Ok();
        }

        return StatusCode(204);
    }

    public async Task<IActionResult> UpdateSurvey()
    {
        var surveyModel = await HttpContext.Request.ReadFromJsonAsync<SurveyModel>(_options);

        var updatedSurveyModel = await _toDb.UpdateToDatabaseAsync(surveyModel);

        return Json(updatedSurveyModel, _options);
    }

    public async Task<IActionResult> DeleteSurvey(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var result = await _toDb.DeleteToDatabaseAsync(id.Value);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}