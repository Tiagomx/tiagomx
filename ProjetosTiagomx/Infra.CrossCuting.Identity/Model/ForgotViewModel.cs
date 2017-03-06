using System.ComponentModel.DataAnnotations;

namespace Infra.CrossCuting.Identity.Model
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}