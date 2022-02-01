namespace Otal.lmaoo.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Display(Name = "User Name")]
        public string Username { get; set; }

        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}