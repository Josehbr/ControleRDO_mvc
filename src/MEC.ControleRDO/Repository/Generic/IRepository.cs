using MEC.ControleRDO.Models.Base;

namespace MEC.ControleRDO.Repository.Generic
{
    public interface IRepository<T> where T : BaseModel
    {
        T Create(T item);
        T Update(T item);
        List<T> FindAll();
        T FindById(long Id);
        void Delete(long Id);
    }
}
