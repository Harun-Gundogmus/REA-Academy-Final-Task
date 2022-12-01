using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TaskAdminUI.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new CommentDal());
        public IActionResult Index()
        {
            var values = cm.GetAllComments();
            return View(values);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CommentEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CommentEkle(TaskComment taskComment)
        {
            CommentValidation comVld = new CommentValidation();
            FluentValidation.Results.ValidationResult results = comVld.Validate(taskComment);
            if (results.IsValid)
            {
                cm.AddComment(taskComment);
                return RedirectToAction("Index", "Comment");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View("CommentEkle");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CommentGuncelle(int id)
        {
            var values = cm.getCommentByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult CommentGuncelle(TaskComment taskComment)
        {
            CommentValidation comVld = new CommentValidation();
            FluentValidation.Results.ValidationResult results = comVld.Validate(taskComment);
            if (results.IsValid)
            {
                cm.UpdateComment(taskComment);
                return RedirectToAction("Index", "Comment");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("CommentGuncelle");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CommentSil(int id)
        {
            var result = cm.getCommentByID(id);
            cm.DeleteComment(result);

            return RedirectToAction("Index", "Comment");

        }
    }
}
