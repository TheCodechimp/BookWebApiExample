using System.Collections.Generic;

namespace Models
{
    public interface IRestful<out T>
    {
        IEnumerable<T> List();
        T List(int id);
    }
}