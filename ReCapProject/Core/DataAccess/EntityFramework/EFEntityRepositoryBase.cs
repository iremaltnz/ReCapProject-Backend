using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{

    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
        {
            public void Add(TEntity entity)
            {

                using (TContext context = new TContext())
              {
                //IDısposable pattern implementation of c# -> araştır
                //using bittiği anda belleği temizleme

                var addedEntity = context.Entry(entity);//veri kaynağından gönderilen producta eşleştir
                //referansı yakalama
                addedEntity.State = EntityState.Added;
                //eklenecek nesne
                context.SaveChanges();
                //Ekleme işlemini yaptı
              }
         }



            public void Delete(TEntity entity)
            {

                using (TContext context = new TContext())
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                }
            }



            public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
            {
                using (TContext context = new TContext())
                {
                    return filter == null
                        ? context.Set<TEntity>().ToList()
                        : context.Set<TEntity>().Where(filter).ToList();
                    // select*from products : filtre konulmuş hali 
                }
            }

            public TEntity GetById(Expression<Func<TEntity, bool>> filter)
            {
                using (TContext context = new TContext())
                {
                    return context.Set<TEntity>().SingleOrDefault(filter);
                }
            }



            public void Update(TEntity entity)
            {

                using (TContext context = new TContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
}
