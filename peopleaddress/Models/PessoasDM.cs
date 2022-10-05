using Dapper.Contrib.Extensions;

namespace peopleaddress.Models
{
    [Table("pessoas")]
    public class PessoasDM
    {
        [Key]
        public int pessoaId { get; set; }

        public string? nome { get; set; }
        
        public string dataNascimento { get; set; }
        
        public int idade { get; set; }

        public string? email { get; set; }

        public string? telefone { get; set; }

        public string? celular { get; set; }

        public DateTime cadastro { get; set; }

        public DateTime alteracao { get; set; }
    }
}
