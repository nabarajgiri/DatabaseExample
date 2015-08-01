using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Framework.Repository
{
    public interface IGenericRepository<T> where T:class
    {
        int insert(T t);
        List<T> GetALL();
    }
}
