using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommmerce.Entities.Dtos
{
    public class UserAddDto
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "Kullanici Adiniz minimum 3 karakterden fazla olamaz.")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Mail Adresiniz gecerli degil.")]
        [DisplayName("Mail")]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "Sifreniz minimum 3 karakterden fazla olamaz.")]
        [DisplayName("Sifreniz")]
        public string Password { get; set; }
    }
}
