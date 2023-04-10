using ResumeProject.Models;
using System.Linq;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class TechnologyController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();

        // GET: Technology
        public ActionResult Index()
        {
            var values = db.TblTechnology.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTechnology()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTechnology(TblTechnology technology)
        {
            db.TblTechnology.Add(technology);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTechnology(int id)
        {
            var value = db.TblTechnology.Find(id);
            db.TblTechnology.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTechnology(int id)
        {
            var value = db.TblTechnology.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTechnology(TblTechnology technology)
        {
            var value = db.TblTechnology.Find(technology.TechnologyID);
            value.TechnologyTitle = technology.TechnologyTitle;
            value.TechnologyValue = technology.TechnologyValue;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}