using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;
using System.Collections.Generic;

namespace ReportTestWebApi.Repositories.Abstracts
{
    public interface IApiRepository
    {
        bool Auntheticate(API api);
        User GetUserByUserName(string name);
        IEnumerable<Device> GetActiveVehicle(List<string> groupFilter);
        List<string> GetListFromCommaSeparatedString(string items);
        //List<TripModel> GetTrips(DateTime from, DateTime to, List<string> vehicles);
        //List<object> MultiCall(object[] calls);
        //public string GetZonesAround(Coordinate coordinate, List<Zone> zones);

    }
}
