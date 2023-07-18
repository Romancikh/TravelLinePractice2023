using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string FirstNumber { get; set; } = string.Empty;

        [BindProperty]
        public string SecondNumber { get; set; } = string.Empty;

        [BindProperty]
        public string Operation { get; set; } = string.Empty;

        public IndexModel( ILogger<IndexModel> logger )
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return RedirectToPage( "/Result", new { FirstNumber, Operation, SecondNumber } );
        }
    }
}