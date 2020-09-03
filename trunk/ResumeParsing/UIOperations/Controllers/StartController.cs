using System.Web.Mvc;

namespace UIOperations.Controllers
{
    public class StartController : Controller
    {
        // GET: Start
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult EnterKeywords()
        //{
        //    DbOperations.DataBaseOperationsController.EnterKeywords();
        //    return RedirectToAction("Index");
        //}
    }
}