using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportTestWebApi.Repositories.Abstracts
{
    public interface IUnitOfWork
    {
        IApiRepository ApiRepository { get; }
    }
}
