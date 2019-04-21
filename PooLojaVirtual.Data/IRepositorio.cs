using System.Collections.Generic;

namespace PooLojaVirtual.Data
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> GetAll();
    }
}