using Geotab.Checkmate;

namespace ReportTestWebApi.Models
{
    public class Credential
    {
        public string Username { get; set; }
        public string Server { get; set; }
        public string SessionId { get; set; }
        public string Database { get; set; }
        public string GroupFilter { get; set; }
        public API API => new API(Username, null, SessionId, Database, Server);
    }
}
