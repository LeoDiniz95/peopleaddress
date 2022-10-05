using peopleaddress.GeneralData;

namespace peopleaddress.Repository
{
    public class Endereco
    {
        private DbSession _session;

        public Endereco(DbSession dbSession)
        {
            _session = dbSession;
        }
    }
}
