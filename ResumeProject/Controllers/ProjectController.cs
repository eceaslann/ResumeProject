using ResumeProject.Models;
using System.Linq;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class ProjectController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();

        // GET: Project
        public ActionResult Index()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProject project)
        {
            db.TblProject.Add(project);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProject.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject project)
        {
            var value = db.TblProject.Find(project.ProjectID);
            value.ProjectTitle = project.ProjectTitle;
            value.ProjectDescription = project.ProjectDescription;
            value.ProjectImageUrl = project.ProjectImageUrl;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}