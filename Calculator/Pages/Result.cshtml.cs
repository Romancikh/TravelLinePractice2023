using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class ResultModel : PageModel
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public string Operation { get; set; } = string.Empty;

        public void OnGet( int firstNumber, int secondNumber, string operation )
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;
        }
    }
}
