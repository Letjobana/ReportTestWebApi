using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;
using ReportTestWebApi.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportTestWebApi.Repositories.Concretes
{

    public class ApiRepository : IApiRepository
    {
        private API _api;

        public bool Auntheticate(API api)
        {
            try
            {
                _api = api;
                var user = GetUserByUserName(_api.UserName);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Device> GetActiveVehicle(List<string> groupFilter)
        {
            try
            {
                return _api.CallAsync<List<Device>>("Get", typeof(Device), new
                {
                    search = new DeviceSearch
                    {
                        Groups = groupFilter.Select(g => new GroupSearch { Id = Id.Create(g) }).ToList()
                    }
                }).Result.Where(x => x.IsActive());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> GetListFromCommaSeparatedString(string items)
        {
            try
            {
                string[] strArray = new string[0];
                if (items != null)
                    strArray = items.Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries);
                return ((IEnumerable<string>)strArray).Select<string, string>((Func<string, string>)(i => i)).ToList<string>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserByUserName(string name)
        {
            try
            {
                return _api.CallAsync<List<User>>("Get", typeof(User), new
                {
                    search = new UserSearch
                    {
                        Name = name
                    }
                }).Result.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
