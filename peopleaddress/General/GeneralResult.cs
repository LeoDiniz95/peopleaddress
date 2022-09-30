using System.Net;

namespace peopleaddress.General
{
    public class GeneralResult
    {
        public string transactionId { get; set; }

        public bool failure { get; set; }

        public object data { get; set; }

        public List<string> errors { get; set; }

        public string code { get; set; }

        public string date { get; set; }

        public GeneralResult()
        {
            failure = false;
            errors = new List<string>();
            code = ((int)HttpStatusCode.OK).ToString();
            date = DateTime.Now.ToLongDateString();
        }

        public void AddError(Exception ex)
        {
            failure = true;
            data = new { };
            code = ((int)HttpStatusCode.BadRequest).ToString();
            errors.Add(ex.Message);
        }
    }
}
