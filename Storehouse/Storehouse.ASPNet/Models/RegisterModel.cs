using System.ComponentModel.DataAnnotations;


namespace Storehouse.ASPNet.Models
{

    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Different password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}