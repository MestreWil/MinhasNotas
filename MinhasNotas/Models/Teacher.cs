using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MinhasNotas.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        [DisplayName("Senha")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Password { get; set; }
    }
}
