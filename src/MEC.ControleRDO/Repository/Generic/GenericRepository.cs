using MEC.ControleRDO.Context;
using MEC.ControleRDO.Models.Base;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace MEC.ControleRDO.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseModel
    {

        private ControleRdoContext _context;

        private DbSet<T> dataset;

        public GenericRepository(ControleRdoContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
                    if (result != null)
                    {
                        _context.Entry(result).CurrentValues.SetValues(item);
                        _context.SaveChanges();
                        transaction.Commit();
                        return result;
                    }
                    else
                    {
                        transaction.Rollback();
                        return null;
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {

                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }
}
