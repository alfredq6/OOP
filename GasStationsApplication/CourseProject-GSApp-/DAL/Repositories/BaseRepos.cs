using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class BaseRepos<TEntity> where TEntity : BaseModel
    {
        protected DbSet<TEntity> Entity { get; set; }
        public GSContext GSContext { get; set; }

        public BaseRepos(GSContext modelContext)
        {
            GSContext = modelContext;
            Entity = GSContext.Set<TEntity>();
        }

        public TEntity Get(string modelName)
        {
            return GetAll().FirstOrDefault(x => x.Name == modelName);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entity.ToList();
        }

        public TEntity Save(TEntity model)
        {
            Entity.Add(model);
            GSContext.SaveChanges();
            return model;
        }

        public TEntity Remove(TEntity model)
        {
            GSContext.Entry<TEntity>(model).State = EntityState.Deleted;
            GSContext.SaveChanges();
            return model;
        }

        public TEntity Update(TEntity model)
        {
            GSContext.Entry<TEntity>(model).State = EntityState.Modified;
            GSContext.SaveChanges();
            return model;
        }
    }
}