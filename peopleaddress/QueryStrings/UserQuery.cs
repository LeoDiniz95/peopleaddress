namespace peopleaddress.QueryStrings
{
    public class UserQuery
    {
        public static string Insert = @"Insert Into users (username,
                                                             password,
                                                             role,
                                                             status,
                                                             cadastro)
                                                             VALUES
                                                            (@username,
                                                             @password,
                                                             @role,
                                                             @status,
                                                             NOW());
                                                            SELECT LAST_INSERT_ID();";
    }
}
