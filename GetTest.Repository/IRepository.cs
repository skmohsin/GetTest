using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTest.Repository
{
    public interface IRepository
    {
        T Read<T>(int entityId) where T : Entity;
        void Persist<T>(T entity) where T : Entity;
        IQueryable<T> Query<T>() where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        Task<int> ExecuteStoreProcedureAsync(string storeProcedureDefinition, params object[] parameters);
    }
}
