using Geotab.Checkmate.ObjectModel;

namespace ReportTestWebApi.Models
{
    public class TripModel
    {
        public string DeviceDesc { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Location { get; set; }
        public Coordinate StopPoint { get; set; }
    }
}
