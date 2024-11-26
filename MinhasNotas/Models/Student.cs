using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MinhasNotas.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        [DisplayName("Senha")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Password { get; set; }
    }
}
