using System.ComponentModel.DataAnnotations;

namespace FormularioInscricao.Models
{
    public class Inscricao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória")]
        public string Categoria { get; set; }

        public string Atividades { get; set; }

        public decimal Valor { get; set; }
    }
}
