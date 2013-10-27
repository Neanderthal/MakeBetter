using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeBetter.Models;

namespace MakeBetter.Controllers
{   
    public class CommentController : Controller
    {
		private readonly ITaskRepository taskRepository;
		private readonly IUserRepository userRepository;
		private readonly ICommentRepository commentRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CommentController() : this(new TaskRepository(), new UserRepository(), new CommentRepository())
        {
        }

        public CommentController(ITaskRepository taskRepository, IUserRepository userRepository, ICommentRepository commentRepository)
        {
			this.taskRepository = taskRepository;
			this.userRepository = userRepository;
			this.commentRepository = commentRepository;
        }

        //
        // GET: /Comment/

        public ViewResult Index()
        {
            return View(commentRepository.AllIncluding(comment => comment.Task, comment => comment.User));
        }

        //
        // GET: /Comment/Details/5

        public ViewResult Details(System.Guid id)
        {
            return View(commentRepository.Find(id));
        }

        //
        // GET: /Comment/Create

        public ActionResult Create()
        {
			ViewBag.PossibleTask = taskRepository.All;
			ViewBag.PossibleUser = userRepository.All;
            return View();
        } 

        //
        // POST: /Comment/Create

        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid) {
                commentRepository.InsertOrUpdate(comment);
                commentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTask = taskRepository.All;
				ViewBag.PossibleUser = userRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Comment/Edit/5
 
        public ActionResult Edit(System.Guid id)
        {
			ViewBag.PossibleTask = taskRepository.All;
			ViewBag.PossibleUser = userRepository.All;
             return View(commentRepository.Find(id));
        }

        //
        // POST: /Comment/Edit/5

        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid) {
                commentRepository.InsertOrUpdate(comment);
                commentRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTask = taskRepository.All;
				ViewBag.PossibleUser = userRepository.All;
				return View();
			}
        }

        //
        // GET: /Comment/Delete/5
 
        public ActionResult Delete(System.Guid id)
        {
            return View(commentRepository.Find(id));
        }

        //
        // POST: /Comment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(System.Guid id)
        {
            commentRepository.Delete(id);
            commentRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                taskRepository.Dispose();
                userRepository.Dispose();
                commentRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

