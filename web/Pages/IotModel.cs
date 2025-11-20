using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_test.Pages;

public class IotModel : PageModel
{
    private readonly ILogger<IotModel> _logger;

    public IotModel(ILogger<IotModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("IoT page accessed");
    }
}