using System;
using Microsoft.EntityFrameworkCore;

namespace oracle.api.Infrastructure.Interfaces
{
    public interface IUnitOfWork<T> where T : DbContext, IDisposable
    {

        void Save();
    }
}