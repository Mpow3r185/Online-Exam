using Microsoft.AspNetCore.Mvc;

namespace Tahaluf.PlusExam.API.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
