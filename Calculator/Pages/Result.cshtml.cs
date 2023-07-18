using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace Calculator.Pages
{
    public class ResultModel : PageModel
    {
        public string FirstNumber { get; set; } = string.Empty;

        public string SecondNumber { get; set; } = string.Empty;

        public string Operation { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;

        public string CarryLine { get; set; } = "0";

        public void OnGet( string firstNumber, string secondNumber, string operation )
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;
            Addition();
        }

        public void Addition()
        {
            int maxLength = Math.Max( FirstNumber.Length, SecondNumber.Length );

            FirstNumber = PadNumber( FirstNumber, maxLength );
            SecondNumber = PadNumber( SecondNumber, maxLength );

            int carry = 0;
            StringBuilder resultBuilder = new();
            StringBuilder carryLineBuilder = new();

            for ( int i = maxLength - 1; i >= 0; i-- )
            {
                int firstDigit = FirstNumber[ i ] - '0';
                int secondDigit = SecondNumber[ i ] - '0';

                int stepResult = firstDigit + secondDigit + carry;

                if ( stepResult >= 10 )
                {
                    carry = 1;
                    stepResult -= 10;
                }
                else
                {
                    carry = 0;
                }

                resultBuilder.Insert( 0, stepResult );
                carryLineBuilder.Insert( 0, carry );
            }

            if ( carry > 0 )
            {
                resultBuilder.Insert( 0, "1" );
            }
            else
            {
                carryLineBuilder.Remove( 0, 1 );
            }

            Result = resultBuilder.ToString();
            CarryLine = carryLineBuilder.ToString();

            maxLength = Math.Max( maxLength, Result.Length );
            FirstNumber = PadNumber( FirstNumber, maxLength );
            SecondNumber = PadNumber( SecondNumber, maxLength );
            Result = PadNumber( Result, maxLength );
        }

        private string PadNumber( string number, int length )
        {
            if ( number.Length < length )
            {
                return number.PadLeft( length, '0' );
            }

            return number;
        }
    }
}
