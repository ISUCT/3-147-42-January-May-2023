using application.Additionals;
using Microsoft.AspNetCore.Mvc;
using application.Models;
namespace application.Controllers;

public class HomeController : Controller
{
    private readonly DatabaseContext _db;

    public async Task Index()
    {
        await HttpContext.Response.SendFileAsync("wwwroot/Surveys.html");
    }

    public HomeController(DatabaseContext db)
    {
        _db = db;
    }

    public IActionResult Get(int? id)
    {
        if (id is not null)
        {
            var questionStrings = _db.Questions.Where(q => q.Id == id).ToList();
            if (questionStrings.Count > 0)
            {
                var questionString = questionStrings[0];
                return Content($"[{questionString.Id}] {questionString.Text}");
            }
            return Content($"There are no strings with that id :(");
        }

        var responseString = "Questions: \n";

        var questions = _db.Questions.ToList();
        foreach (var question in questions)
        {
            responseString += $"[{question.Id}] {question.Text} {question.Type} \n";
        }

        return Content(responseString);
    }

    public async Task<IActionResult> Add(string? text)
    {
        if (text is not null)
        {
            var question = new Question();
            question.Text = text;
            question.Type = 0;
            _db.Questions.Add(question);
            await _db.SaveChangesAsync();
            return Content($"New string has been added successfully");
        }

        return Content("Smth went wrong :(");
    }
}
