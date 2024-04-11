using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace teamCityTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WidgetsController : ControllerBase
{
    private readonly IMongoCollection<Widget> widgets;
    //some comment
    //some other new change
    // new new trigger
    public WidgetsController(WidgetContext context)
    {
        widgets = context.WidgetSet;
    }
    // GET: api/<WidgetsController>
    [HttpGet]
    public ActionResult<List<Widget>> Get()
    {
        var filter = Builders<Widget>.Filter.Empty;

        return widgets.Find(filter).ToList();
    }
}