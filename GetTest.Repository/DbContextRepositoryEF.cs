using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTest.Repository
{
    public class DbContextRepositoryEF : IRepository
    {
        private readonly DbContext dbContext = null;
        public DbContextRepositoryEF(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public T Read<T>(int entityId) where T : Entity
        {
            return this.dbContext.Set<T>().FirstOrDefault(e => e.Id == entityId);
        }
        public IQueryable<T> Query<T>() where T : Entity
        {
            return this.dbContext.Set<T>();
        }
        public void Persist<T>(T entity) where T : Entity
        {
             if (entity.Id != 0)
            {
                entity.ModifiedBy = this.context.Current.UserId;
                entity.ModifiedOn = DateTime.Now;

                this.dbContext.Entry<T>(entity).State = EntityState.Modified;
            }
            else
            {
                if (this.context.Current != null)
                {
                    entity.CreatedBy = this.context.Current.UserId;
                    entity.CreatedOn = DateTime.Now;
                    entity.TenantId = this.context.Current.TenantId;
                }

                this.dbContext.Set<T>().Add(entity);

                if (!ApplicationConfiguration.IsOfflineApplication)
                {
                    (this as IRepository).Flush();
                }
            }
        }
        public void Delete<T>(T entity) where T : Entity
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public Task<int> ExecuteStoreProcedureAsync(string storeProcedureDefinition, params object[] parameters)
        {
            return await this.dbContext.Database.ExecuteSqlCommandAsync(storeProcedureDefinition, parameters);
        }
    }
}
