using System.ComponentModel.DataAnnotations;

namespace Videos.Rest.Models.BindingModels
{
    public class LoginUserBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}