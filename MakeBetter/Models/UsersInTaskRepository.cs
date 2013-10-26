using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MakeBetter.Models
{ 
    public class UsersInTaskRepository : IUsersInTaskRepository
    {
        MakeBetterEntities context = new MakeBetterEntities();

        public IQueryable<UsersInTask> All
        {
            get { return context.UsersInTask; }
        }

        public IQueryable<UsersInTask> AllIncluding(params Expression<Func<UsersInTask, object>>[] includeProperties)
        {
            IQueryable<UsersInTask> query = context.UsersInTask;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public UsersInTask Find(long id)
        {
            return context.UsersInTask.Find(id);
        }

        public void InsertOrUpdate(UsersInTask usersintask)
        {
            if (usersintask.UsersInTaskId == default(long)) {
                // New entity
                context.UsersInTask.Add(usersintask);
            } else {
                // Existing entity
                context.Entry(usersintask).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var usersintask = context.UsersInTask.Find(id);
            context.UsersInTask.Remove(usersintask);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IUsersInTaskRepository : IDisposable
    {
        IQueryable<UsersInTask> All { get; }
        IQueryable<UsersInTask> AllIncluding(params Expression<Func<UsersInTask, object>>[] includeProperties);
        UsersInTask Find(long id);
        void InsertOrUpdate(UsersInTask usersintask);
        void Delete(long id);
        void Save();
    }
}