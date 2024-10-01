using System.ComponentModel.DataAnnotations;

namespace DemoProduct.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz")]
        public string Password { get; set; }
    }
}
