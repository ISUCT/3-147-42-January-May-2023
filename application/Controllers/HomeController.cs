using application.Additionals;
using Microsoft.AspNetCore.Mvc;
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
}
