using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakeBetter.Models;

namespace MakeBetter.Controllers
{   
    public class UserController : Controller
    {
		private readonly IUserRepository userRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public UserController() : this(new UserRepository())
        {
        }

        public UserController(IUserRepository userRepository)
        {
			this.userRepository = userRepository;
        }

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(userRepository.AllIncluding(user => user.Comment, user => user.Task, user => user.UsersInTask));
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(System.Guid id)
        {
            return View(userRepository.Find(id));
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid) {
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(System.Guid id)
        {
             return View(userRepository.Find(id));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid) {
                userRepository.InsertOrUpdate(user);
                userRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(System.Guid id)
        {
            return View(userRepository.Find(id));
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(System.Guid id)
        {
            userRepository.Delete(id);
            userRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                userRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

