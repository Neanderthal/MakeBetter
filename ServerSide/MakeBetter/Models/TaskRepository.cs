using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MakeBetter.Models
{ 
    public class TaskRepository : ITaskRepository
    {
        MakeBetterEntities context = new MakeBetterEntities();

        public IQueryable<Task> All
        {
            get { return context.Task; }
        }

        public IQueryable<Task> AllIncluding(params Expression<Func<Task, object>>[] includeProperties)
        {
            IQueryable<Task> query = context.Task;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Task Find(System.Guid id)
        {
            return context.Task.Find(id);
        }

        public void InsertOrUpdate(Task task)
        {
            if (task.TaskId == default(System.Guid)) {
                // New entity
                task.TaskId = Guid.NewGuid();
                context.Task.Add(task);
            } else {
                // Existing entity
                context.Entry(task).State = EntityState.Modified;
            }
        }

        public void Delete(System.Guid id)
        {
            var task = context.Task.Find(id);
            context.Task.Remove(task);
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

    public interface ITaskRepository : IDisposable
    {
        IQueryable<Task> All { get; }
        IQueryable<Task> AllIncluding(params Expression<Func<Task, object>>[] includeProperties);
        Task Find(System.Guid id);
        void InsertOrUpdate(Task task);
        void Delete(System.Guid id);
        void Save();
    }
}