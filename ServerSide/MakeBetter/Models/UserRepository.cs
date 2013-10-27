using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MakeBetter.Models
{ 
    public class UserRepository : IUserRepository
    {
        MakeBetterEntities context = new MakeBetterEntities();

        public IQueryable<User> All
        {
            get { return context.User; }
        }

        public IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = context.User;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public User Find(System.Guid id)
        {
            return context.User.Find(id);
        }

        public void InsertOrUpdate(User user)
        {
            if (user.UserId == default(System.Guid)) {
                // New entity
                user.UserId = Guid.NewGuid();
                context.User.Add(user);
            } else {
                // Existing entity
                context.Entry(user).State = EntityState.Modified;
            }
        }

        public void Delete(System.Guid id)
        {
            var user = context.User.Find(id);
            context.User.Remove(user);
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

    public interface IUserRepository : IDisposable
    {
        IQueryable<User> All { get; }
        IQueryable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties);
        User Find(System.Guid id);
        void InsertOrUpdate(User user);
        void Delete(System.Guid id);
        void Save();
    }
}