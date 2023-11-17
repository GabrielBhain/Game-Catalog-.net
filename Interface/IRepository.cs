using System.Collections.Generic;

namespace DIO.Games.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T GetById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}