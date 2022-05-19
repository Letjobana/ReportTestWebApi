using ReportTestWebApi.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportTestWebApi.Repositories.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApiRepository ApiRepository { get; private set; }
        public UnitOfWork()
        {
            ApiRepository = new ApiRepository();
        }
    }
}
