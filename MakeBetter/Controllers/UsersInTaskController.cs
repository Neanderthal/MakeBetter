using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeBetter.Models;

namespace MakeBetter.Controllers
{   
    public class UsersInTaskController : Controller
    {
		private readonly ITaskRepository taskRepository;
		private readonly IUserRepository userRepository;
		private readonly IUsersInTaskRepository usersintaskRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public UsersInTaskController() : this(new TaskRepository(), new UserRepository(), new UsersInTaskRepository())
        {
        }

        public UsersInTaskController(ITaskRepository taskRepository, IUserRepository userRepository, IUsersInTaskRepository usersintaskRepository)
        {
			this.taskRepository = taskRepository;
			this.userRepository = userRepository;
			this.usersintaskRepository = usersintaskRepository;
        }

        //
        // GET: /UsersInTask/

        public ViewResult Index()
        {
            return View(usersintaskRepository.AllIncluding(usersintask => usersintask.Task, usersintask => usersintask.User));
        }

        //
        // GET: /UsersInTask/Details/5

        public ViewResult Details(long id)
        {
            return View(usersintaskRepository.Find(id));
        }

        //
        // GET: /UsersInTask/Create

        public ActionResult Create()
        {
			ViewBag.PossibleTask = taskRepository.All;
			ViewBag.PossibleUser = userRepository.All;
            return View();
        } 

        //
        // POST: /UsersInTask/Create

        [HttpPost]
        public ActionResult Create(UsersInTask usersintask)
        {
            if (ModelState.IsValid) {
                usersintaskRepository.InsertOrUpdate(usersintask);
                usersintaskRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTask = taskRepository.All;
				ViewBag.PossibleUser = userRepository.All;
				return View();
			}
        }
        
        //
        // GET: /UsersInTask/Edit/5
 
        public ActionResult Edit(long id)
        {
			ViewBag.PossibleTask = taskRepository.All;
			ViewBag.PossibleUser = userRepository.All;
             return View(usersintaskRepository.Find(id));
        }

        //
        // POST: /UsersInTask/Edit/5

        [HttpPost]
        public ActionResult Edit(UsersInTask usersintask)
        {
            if (ModelState.IsValid) {
                usersintaskRepository.InsertOrUpdate(usersintask);
                usersintaskRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTask = taskRepository.All;
				ViewBag.PossibleUser = userRepository.All;
				return View();
			}
        }

        //
        // GET: /UsersInTask/Delete/5
 
        public ActionResult Delete(long id)
        {
            return View(usersintaskRepository.Find(id));
        }

        //
        // POST: /UsersInTask/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            usersintaskRepository.Delete(id);
            usersintaskRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                taskRepository.Dispose();
                userRepository.Dispose();
                usersintaskRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

