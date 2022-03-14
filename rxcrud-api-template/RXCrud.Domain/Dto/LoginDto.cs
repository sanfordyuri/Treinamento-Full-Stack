using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RXCrud.Domain.Dto
{
    [DisplayName("Login")]
    public class LoginDto
    {
        [Required(ErrorMessage = "Campo 'Usuario' obrigatório.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo 'Senha' obrigatório.")]
        public string Senha { get; set; }
    }
}