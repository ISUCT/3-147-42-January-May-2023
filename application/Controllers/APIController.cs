using application.Additionals;
using application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace application.Controllers;

public class APIController : Controller
{
    private DatabaseContext _db;
    
    public APIController(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> GetSurvey(int? id)
    {
        if (id is not null)
        {
            var survey = await _db.Surveys.FirstOrDefaultAsync(s => s.Id == id);
            
            if (survey is null)
            {
                return NotFound();
            }
            
            return Json(survey);
        }

        var surveys = await _db.Surveys.ToListAsync();

        return Json(surveys);
    }

    public async Task<IActionResult> AddSurvey()
    {
        var survey = await HttpContext.Request.ReadFromJsonAsync<Survey>();
        
        if (survey is not null)
        {
            _db.Surveys.Add(survey);
            await _db.SaveChangesAsync();
            return Ok();
        }

        return StatusCode(204);
    }

    public async Task<IActionResult> UpdateSurvey()
    {
        var survey = await HttpContext.Request.ReadFromJsonAsync<Survey>();

        if (survey is not null)
        {
            _db.Surveys.Update(survey);
            await _db.SaveChangesAsync();
            return Ok();
        }

        return StatusCode(204);

    }

    public async Task<IActionResult> DeleteSurvey(int? id)
    {
        if (id is not null)
        {
            var survey = await _db.Surveys.FirstOrDefaultAsync(s => s.Id == id);
            if (survey is not null)
            {
                _db.Surveys.Remove(survey);
                await _db.SaveChangesAsync();
                return Ok();
            }
        }



        return NotFound();
    }
}