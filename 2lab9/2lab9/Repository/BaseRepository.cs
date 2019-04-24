using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab9.Repository
{
    public interface BaseRepository<T> where T : class
    {
        T Save(T obj);
    }
}
