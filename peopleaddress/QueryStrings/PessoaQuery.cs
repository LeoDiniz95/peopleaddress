﻿namespace peopleaddress.QueryStrings
{
    public static class PessoaQuery
    {
        public static string GetAll = @"SELECT pessoaId," +
                                              "nome," +
                                              "idade," +
                                              "email," +
                                              "telefone," +
                                              "celular," +
                                              "cadastro," +
                                              "alteracao  FROM pessoas";

        public static string Get = @"SELECT pessoaId,
                                              nome,
                                              idade,
                                              email,
                                              telefone,
                                              celular,
                                              cadastro,
                                              alteracao FROM pessoas
                                               where pessoaId = {0}";

        public static string Insert = @"Insert Into pessoas (nome,
                                                             idade,
                                                             email,
                                                             telefone,
                                                             celular,
                                                             cadastro)
                                                             VALUES
                                                            ('{nome}',
                                                             {idade},
                                                             '{email}',
                                                             '{telefone}',
                                                             '{celular}',
                                                             NOW());
                                          SELECT LAST_INSERT_ID()";


        public static string Update = @"UPDATE pessoas SET nome = '{nome}',
                                                       idade = {idade},
                                                       email = '{email}',
                                                       telefone = '{telefone}',
                                                       celular = '{celular}',
                                                       alteracao = NOW()
													WHERE pessoaId = {pessoaId}";

        public static string Delete = @"DELETE FROM pessoas where pessoaId = {0}";
    }
}