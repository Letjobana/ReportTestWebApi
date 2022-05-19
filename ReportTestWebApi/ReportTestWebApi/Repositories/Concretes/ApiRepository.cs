using Geotab.Checkmate;
using Geotab.Checkmate.ObjectModel;
using ReportTestWebApi.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
