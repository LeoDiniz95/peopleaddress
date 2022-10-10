namespace peopleaddress.Request
{
    public class UserRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string? status { get; set; }
    }
}
