using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Interfaces
{
    public interface IRepository<T>  where T : class
    {
        IEnumerable<T> GetAll();
        Task Create(T item);
        Task Edit(T item);
        Task Delete(int id);
        T Get(int id);
    }
}
