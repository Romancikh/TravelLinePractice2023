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

        public List<string> Line { get; set; } = new();

        public void OnGet( string firstNumber, string secondNumber, string operation )
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;
            Proceed();
        }

        private void Proceed()
        {
            switch ( Operation )
            {
                case "addition":
                    Addition();
                    LevelTheLength( true );
                    break;
                case "subtraction":
                    Subtraction();
                    LevelTheLength( true );
                    break;
                default:
                    throw new ArgumentException( "Invalid operation" );
            }
        }

        private void Subtraction()
        {
            int maxLength = Math.Max( FirstNumber.Length, SecondNumber.Length );

            LevelTheLength();

            bool isNegative = false;
            bool borrow = false;
            StringBuilder resultBuilder = new();
            List<string> borrowLine = new();

            if ( int.Parse( FirstNumber ) < int.Parse( SecondNumber ) )
            {
                isNegative = true;
                (FirstNumber, SecondNumber) = (SecondNumber, FirstNumber);
            }

            for ( int i = maxLength - 1; i >= 0; i-- )
            {
                int firstDigit = FirstNumber[ i ] - '0';
                int secondDigit = SecondNumber[ i ] - '0';

                if ( borrow )
                {
                    firstDigit--;
                    borrow = false;
                    borrowLine.Insert( 0, "." );
                }

                if ( firstDigit < secondDigit )
                {
                    firstDigit += 10;
                    borrow = true;
                    if ( borrowLine.Count == 0 || borrowLine[ 0 ] != "." )
                    {
                        borrowLine.Insert( 0, "10" );
                    }
                }

                int stepResult = firstDigit - secondDigit;
                resultBuilder.Insert( 0, stepResult );
            }

            Result = resultBuilder.ToString().TrimStart( '0' );
            Line = borrowLine;

            if ( Result.Length == 0 )
            {
                Result = "0";
            }

            if ( isNegative )
            {
                Result = "-" + Result;
            }
        }

        private void Addition()
        {
            int maxLength = Math.Max( FirstNumber.Length, SecondNumber.Length );

            LevelTheLength();

            int carry = 0;
            StringBuilder resultBuilder = new();
            List<string> carryLine = new();

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
                carryLine.Insert( 0, carry.ToString() );
            }

            if ( carry > 0 )
            {
                resultBuilder.Insert( 0, "1" );
            }
            else
            {
                carryLine.RemoveAt( 0 );
            }

            Result = resultBuilder.ToString();
            Line = carryLine;
        }

        private static string PadNumber( string number, int length )
        {
            if ( number.Length < length )
            {
                return number.PadLeft( length, '0' );
            }

            return number;
        }

        private void LevelTheLength( bool withResult = false )
        {
            int maxLength = Math.Max( FirstNumber.Length, SecondNumber.Length );
            if ( withResult )
            {
                maxLength = Math.Max( maxLength, Result.Length );
                Result = PadNumber( Result, maxLength );
            }
            FirstNumber = PadNumber( FirstNumber, maxLength );
            SecondNumber = PadNumber( SecondNumber, maxLength );
        }
    }
}
