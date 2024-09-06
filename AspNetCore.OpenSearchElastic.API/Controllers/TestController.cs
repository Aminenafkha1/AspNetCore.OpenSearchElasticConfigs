using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.OpenSearchElastic.API.Controllers;
[Route("api/[controller]")]
[ApiController] 
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {            
        _logger.LogError(new Exception("An error occurred."), "An error occurred in the Index action."); 
        throw new Exception("An error occurred.");
        return NotFound();
    }
}