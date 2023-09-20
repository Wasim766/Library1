using System.Threading.Tasks;
using System.Web.Mvc;

public class HomeController : Controller
{
    private readonly StackOverflowService _soService;

    public HomeController()
    {
        _soService = new StackOverflowService();
    }

    public async Task<ActionResult> Index()
    {
        var questions = await _soService.GetLatestQuestions();
        return View(questions);
    }

    public async Task<ActionResult> QuestionDetails(int id)
    {
        var question = await _soService.GetQuestionDetails(id);
        return View(question);
    }
}
