namespace peopleaddress.Models
{
    public class UsersDM
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public DateTime cadastro { get; set; }
        public DateTime alteracao { get; set; }
    }
}
