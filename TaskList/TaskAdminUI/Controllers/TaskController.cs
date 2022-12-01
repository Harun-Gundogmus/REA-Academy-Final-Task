using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TaskAdminUI.Controllers
{
	public class TaskController : Controller
	{
		TaskOwnerManager tom = new TaskOwnerManager(new TaskOwnerDal());
		public IActionResult Index()
		{
			var values = tom.getAllTasks();
			return View(values);
		}
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult TaskEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskEkle(TaskOwner task)
        {
            TaskValidation tskVld = new TaskValidation();
            FluentValidation.Results.ValidationResult results = tskVld.Validate(task);
            if (results.IsValid)
            {
                tom.AddTask(task);
                return RedirectToAction("Index", "Task");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

                return View("TaskEkle");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult TaskGuncelle(int id)
        {
            var values = tom.getTaskByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult TaskGuncelle(TaskOwner task)
        {
            TaskValidation tskVld = new TaskValidation();
            FluentValidation.Results.ValidationResult results = tskVld.Validate(task);
            if (results.IsValid)
            {
                tom.UpdateTask(task);
                return RedirectToAction("Index", "Task");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("TaskGuncelle");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult TaskSil(int id)
        {
            var result = tom.getTaskByID(id);
            tom.DeleteTask(result);

            return RedirectToAction("Index","Task");

        }
    }
}
