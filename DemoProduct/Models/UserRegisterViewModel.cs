using System.ComponentModel.DataAnnotations;

namespace DemoProduct.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen İsim Değerini Giriniz:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyisim Değerini Giriniz:")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını  Giriniz:")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen Mail  Giriniz:")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Lütfen Cinsiyet belirtiniz")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Lütfen Şifrenizi  Giriniz:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen  Şifrenizi Tekrar  Giriniz:")]
        [Compare("Password",ErrorMessage ="Lütfen şifrelerinizin eşleştiğine emin olun")]
        public string ConfirmPassword { get; set; }
    }
}
