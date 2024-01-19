using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal interface IService<T>
    {
        List<T> GetAll();
        T? GetDetails(int id);
        int Add(T item);
        int Update(T item);
        int Delete(int id);
    }
}
