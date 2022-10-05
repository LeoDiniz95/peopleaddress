using Dapper.Contrib.Extensions;

namespace peopleaddress.Models
{
    [Table("endereco")]
    public class EnderecoDM
    {
        [Key]
        public int enderecoId { get; set; }

        public int pessoaId { get; set; }

        public string? logradouro { get; set; }

        public int? numero { get; set; }

        public string? bairro { get; set; }

        public string? cidade { get; set; }

        public string? uf { get; set; }

        public DateTime cadastro { get; set; }

        public DateTime alteracao { get; set; }
    }
}
