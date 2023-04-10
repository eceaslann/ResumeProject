using ResumeProject.Models;
using System.Linq;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class CategoryController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();

        // GET: Category
        public ActionResult Index()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory category)
        {
            db.TblCategory.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory category)
        {
            var value = db.TblCategory.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}