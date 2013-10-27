using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MakeBetter.Models
{ 
    public class CommentRepository : ICommentRepository
    {
        MakeBetterEntities context = new MakeBetterEntities();

        public IQueryable<Comment> All
        {
            get { return context.Comment; }
        }

        public IQueryable<Comment> AllIncluding(params Expression<Func<Comment, object>>[] includeProperties)
        {
            IQueryable<Comment> query = context.Comment;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Comment Find(System.Guid id)
        {
            return context.Comment.Find(id);
        }

        public void InsertOrUpdate(Comment comment)
        {
            if (comment.CommentId == default(System.Guid)) {
                // New entity
                comment.CommentId = Guid.NewGuid();
                context.Comment.Add(comment);
            } else {
                // Existing entity
                context.Entry(comment).State = EntityState.Modified;
            }
        }

        public void Delete(System.Guid id)
        {
            var comment = context.Comment.Find(id);
            context.Comment.Remove(comment);
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

    public interface ICommentRepository : IDisposable
    {
        IQueryable<Comment> All { get; }
        IQueryable<Comment> AllIncluding(params Expression<Func<Comment, object>>[] includeProperties);
        Comment Find(System.Guid id);
        void InsertOrUpdate(Comment comment);
        void Delete(System.Guid id);
        void Save();
    }
}