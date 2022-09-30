namespace peopleaddress.QueryStrings
{
    public class EnderecoQuery
    {
        public static string GetAll = @"SELECT  enderecoId,
		                                        pessoaId,
                                                logradouro,
                                                numero,
                                                bairro,
                                                cidade,
                                                uf,
                                                cadastro,
                                                alteracao FROM endereco
                                               where pessoaId = {0}";

        public static string Get = @"SELECT     enderecoId,
		                                        pessoaId,
                                                logradouro,
                                                numero,
                                                bairro,
                                                cidade,
                                                uf,
                                                cadastro,
                                                alteracao FROM endereco
                                               where enderecoId = {0}";

        public static string Insert = @"Insert Into endereco (pessoaId,
                                                             logradouro,
                                                             numero,
                                                             bairro,
                                                             cidade,
                                                             uf,
                                                             cadastro)
                                                            VALUES
                                                             ({pessoaId},
                                                             '{logradouro}',
                                                             {numero},
                                                             '{bairro}',
                                                             '{cidade}',
                                                             '{uf}',
                                                             NOW());
                                            SELECT LAST_INSERT_ID();";


        public static string Update = @"UPDATE endereco SET pessoaId = {pessoaId},
                                                            logradouro = '{logradouro}',
                                                            numero = {numero},
                                                            bairro = '{bairro}',
                                                            cidade = '{cidade}',
                                                            uf = '{uf}',
                                                            alteracao = NOW()
													WHERE enderecoId = {enderecoId}";

        public static string Delete = @"DELETE FROM endereco where enderecoId = {0}";
    }
}
