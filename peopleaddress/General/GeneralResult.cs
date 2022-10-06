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
            ChangeStatus(HttpStatusCode.OK);
            date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        public void ChangeStatus(HttpStatusCode status)
        {
            code = ((int)status).ToString();
        }

        public void AddError(Exception ex)
        {
            failure = true;
            data = new { };
            ChangeStatus(HttpStatusCode.BadRequest);
            errors.Add(ex.Message);
        }
    }
}
