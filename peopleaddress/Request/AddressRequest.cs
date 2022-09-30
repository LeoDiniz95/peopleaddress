namespace peopleaddress.Request
{
    public class AddressRequest
    {
        public int pessoaId { get; set; }

        public string logradouro { get; set; }

        public int numero { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string uf { get; set; }
    }
}
