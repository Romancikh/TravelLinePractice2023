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
            string firstNumber = FirstNumber;
            bool isFirstNumberNegative = IsNegative( FirstNumber );
            if ( isFirstNumberNegative ) firstNumber = firstNumber.TrimStart( '-' );

            string secondNumber = SecondNumber;
            bool isSecondNumberNegative = IsNegative( SecondNumber );
            if ( isSecondNumberNegative ) secondNumber = secondNumber.TrimStart( '-' );

            string largerNumber = MaxStringNumbers( firstNumber, secondNumber );
            string smallerNumber = MinStringNumbers( firstNumber, secondNumber );

            string result = string.Empty;
            List<string> line = new();

            switch ( Operation )
            {
                case "addition":
                    if ( isFirstNumberNegative && isSecondNumberNegative )
                    {
                        Addition( largerNumber, smallerNumber, ref result, ref line );
                        result = '-' + result;
                    }
                    else if ( isFirstNumberNegative )
                    {
                        Subtraction( largerNumber, smallerNumber, ref result, ref line );
                        if ( firstNumber == largerNumber ) result = '-' + result;
                    }
                    else if ( isSecondNumberNegative )
                    {
                        Subtraction( largerNumber, smallerNumber, ref result, ref line );
                        if ( secondNumber == largerNumber ) result = '-' + result;
                    }
                    else
                    {
                        Addition( largerNumber, smallerNumber, ref result, ref line );
                    }
                    break;
                case "subtraction":
                    if ( isFirstNumberNegative && isSecondNumberNegative )
                    {
                        Subtraction( largerNumber, smallerNumber, ref result, ref line );
                        if ( firstNumber == largerNumber ) result = '-' + result;
                    }
                    else if ( isFirstNumberNegative )
                    {
                        Addition( largerNumber, smallerNumber, ref result, ref line );
                        result = '-' + result;
                    }
                    else if ( isSecondNumberNegative )
                    {
                        Addition( largerNumber, smallerNumber, ref result, ref line );
                        if ( firstNumber == largerNumber ) result = '-' + result;
                    }
                    else
                    {
                        Subtraction( largerNumber, smallerNumber, ref result, ref line );
                        if ( secondNumber == largerNumber )
                        {
                            result = '-' + result;
                            (FirstNumber, SecondNumber) = (SecondNumber, FirstNumber);
                            FirstNumber = '-' + FirstNumber;
                            Operation = "addition";
                        }
                    }
                    break;
                default:
                    throw new ArgumentException( "Invalid operation" );
            }
            Result = result;
            FixZero();
            Line = line;
            LevelTheLength();
        }

        /** <summary>Subtracts a smaller number from a larger one</summary> */
        private static void Subtraction( string largerNumber, string smallerNumber, ref string result, ref List<string> line )
        {
            LevelTheLength( ref largerNumber, ref smallerNumber );

            bool borrow = false;
            StringBuilder resultBuilder = new();
            List<string> borrowLine = new();

            for ( int i = largerNumber.Length - 1; i >= 0; i-- )
            {
                int firstDigit = largerNumber[ i ] - '0';
                int secondDigit = smallerNumber[ i ] - '0';

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
                else if ( firstDigit == largerNumber[ i ] - '0' )
                {
                    borrowLine.Insert( 0, "0" );
                }

                int stepResult = firstDigit - secondDigit;
                resultBuilder.Insert( 0, stepResult );
            }

            result = resultBuilder.ToString().TrimStart( '0' );
            line = borrowLine;

            if ( result.Length == 0 )
            {
                result = "0";
            }
        }

        /** <summary>Sums a larger number with a smaller one</summary> */
        private static void Addition( string largerNumber, string smallerNumber, ref string result, ref List<string> line )
        {
            LevelTheLength( ref largerNumber, ref smallerNumber );

            int carry = 0;
            StringBuilder resultBuilder = new();
            List<string> carryLine = new() { "0" };

            for ( int i = largerNumber.Length - 1; i >= 0; i-- )
            {
                int firstDigit = largerNumber[ i ] - '0';
                int secondDigit = smallerNumber[ i ] - '0';

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

            result = resultBuilder.ToString();
            line = carryLine;
        }

        private void LevelTheLength()
        {
            int maxLength = Math.Max( FirstNumber.Length, Math.Max( SecondNumber.Length, Result.Length ) );
            FirstNumber = PadNumber( FirstNumber, maxLength );
            SecondNumber = PadNumber( SecondNumber, maxLength );
            Result = PadNumber( Result, maxLength );
            Line = PadNumber( Line, maxLength );
        }

        private void FixZero()
        {
            if (Result == "-0") Result = "0";
        }

        private static string PadNumber( string number, int length )
        {
            if ( number.Length < length )
            {
                return number.PadLeft( length, '0' );
            }
            return number;
        }

        private static List<string> PadNumber( List<string> number, int length )
        {
            List<string> paddednumber = TrimList( number, "0" );
            while ( paddednumber.Count < length )
            {
                paddednumber.Insert( 0, "0" );
            }
            return paddednumber;
        }

        private static List<string> TrimList( List<string> list, string trim )
        {
            List<string> trimmedList = new( list );
            if ( trimmedList.Count > 0 )
            {
                bool isTrimmed = !( trimmedList[ 0 ] == trim );
                while ( !isTrimmed )
                {
                    trimmedList.RemoveAt( 0 );
                    if ( trimmedList.Count > 0 )
                    {
                        isTrimmed = !( trimmedList[ 0 ] == trim );
                    }
                    else
                    {
                        isTrimmed = true;
                    }
                }
            }

            return trimmedList;
        }

        private static string MaxStringNumbers( string firstNumber, string secondNumber )
        {
            if ( firstNumber.Length > secondNumber.Length )
            {
                return firstNumber;
            }
            else if ( secondNumber.Length > firstNumber.Length )
            {
                return secondNumber;
            }

            for ( int i = 0; i < firstNumber.Length; i++ )
            {
                if ( firstNumber[ i ] > secondNumber[ i ] )
                {
                    return firstNumber;
                }
                else if ( secondNumber[ i ] > firstNumber[ i ] )
                {
                    return secondNumber;
                }
            }

            return firstNumber;
        }

        private static string MinStringNumbers( string firstNumber, string secondNumber )
        {
            if ( firstNumber.Length < secondNumber.Length )
            {
                return firstNumber;
            }
            else if ( secondNumber.Length < firstNumber.Length )
            {
                return secondNumber;
            }

            for ( int i = 0; i < firstNumber.Length; i++ )
            {
                if ( firstNumber[ i ] < secondNumber[ i ] )
                {
                    return firstNumber;
                }
                else if ( secondNumber[ i ] < firstNumber[ i ] )
                {
                    return secondNumber;
                }
            }

            return firstNumber;
        }

        private static void LevelTheLength( ref string firstString, ref string secondString )
        {
            int maxLength = Math.Max( firstString.Length, secondString.Length );
            firstString = PadNumber( firstString, maxLength );
            secondString = PadNumber( secondString, maxLength );
        }

        private static bool IsNegative( string number )
        {
            return number[ 0 ] == '-';
        }
    }
}
