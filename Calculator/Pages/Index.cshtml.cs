using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public int FirstNumber { get; set; }

        [BindProperty]
        public int SecondNumber { get; set; }

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