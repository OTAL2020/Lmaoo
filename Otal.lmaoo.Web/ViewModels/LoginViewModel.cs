namespace Otal.lmaoo.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Username is required Lewis!")]
        public string Username;

        [Required(ErrorMessage = "Password is required")]
        public string Password;
    }
}