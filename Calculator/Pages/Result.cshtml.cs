using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class ResultModel : PageModel
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public string Operation { get; set; } = string.Empty;

        public int Result { get; set; }

        public void OnGet( int firstNumber, int secondNumber, string operation )
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;
            Result = GetResult();
        }

        private int GetResult()
        {
            switch ( Operation )
            {
                case "addition":
                    return FirstNumber + SecondNumber;
                case "subtraction":
                    return FirstNumber - SecondNumber;
                case "multiplication":
                    return FirstNumber * SecondNumber;
                case "division":
                    return FirstNumber / SecondNumber;
                default:
                    throw new ArgumentException( "Invalid operation" );
            }
        }
    }
}
