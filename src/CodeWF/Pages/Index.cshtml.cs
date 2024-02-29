using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeWF.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var domainWithoutPort = Request.Host.Host;
        ViewData["Domain"] = domainWithoutPort;
    }
}
