using System.ComponentModel.DataAnnotations;
using WebUserApi.Entities;

namespace WebUserApi.Models.Users
{
    public class UpdateRequest
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [EnumDataType( typeof( Role ) )]
        public string? Role { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        private string? _password;

        [MinLength( 6 )]
        public string? Password { get => _password; set => _password = ReplaceEmptyWithNull( value ?? "" ); }

        private string? _confirmPassword;

        [Compare( "Password" )]
        public string? ConfirmPassword { get => _confirmPassword; set => _confirmPassword = ReplaceEmptyWithNull( value ?? "" ); }

        private static string? ReplaceEmptyWithNull( string value )
        {
            return string.IsNullOrEmpty( value ) ? null : value;
        }
    }
}
