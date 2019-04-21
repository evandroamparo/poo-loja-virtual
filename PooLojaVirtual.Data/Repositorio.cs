using System.Collections.Generic;
using LiteDB;

namespace PooLojaVirtual.Data
{
    public class Repositorio<T> : IRepositorio<T>
    {
        private LiteRepository _db;

        public Repositorio()
        {
            _db = new LiteRepository("loja.db");
        }
        public IEnumerable<T> GetAll()
        {
            return _db.Query<T>().ToEnumerable();
        }
    }
}