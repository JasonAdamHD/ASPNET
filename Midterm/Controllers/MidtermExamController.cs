using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace Midterm;

public class MidtermExamController : Controller
{
    private readonly MidtermExam _Exam;
    private readonly IConfiguration _Config;
    
    public MidtermExamController(IConfiguration conf, IOptions<MidtermExam> exam)
    {
        _Exam = exam.Value;
    }
    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("TakeTest")]
    [HttpGet]
    public IActionResult TakeTest()
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        return View(questionModels);
    }

    [Route("SubmitTest")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TakeTest(List<TestQuestionModel> model)
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        //TODO: At this point you will only have the raw answers in the model.  Questions did not get posted back.
        //You will need to get the questions again from GetQuestionModels(), then set the answer values on the retrieved list by
        //  matching the two lists based on ID
        if(!ModelState.IsValid)
        {
            return View(questionModels);
        }

        for (int i = 0; i < model.Count; i++)
        {
            for (int ii = 0; ii < questionModels.Count; ii++)
            {
                if (model[i].ID == questionModels[ii].ID)
                {
                    model[i].Question = questionModels[ii].Question;
                    break;
                }
            }
        }

        //TODO: Change the below so that it loads the DisplayResults view, passing in the model

        return View("DisplayResults", model);
    }

    [Route("DisplayResults")]
    [HttpGet]
    public IActionResult DisplayResults(List<TestQuestionModel> model) 
    { 
        return View(model);
    }

    private List<TestQuestionModel> GetQuestionModels()
    {
        List<TestQuestionModel> questionModels = new List<TestQuestionModel>();
        foreach(var question in _Exam.Questions)
        {
            if(question.QuestionType == "TrueFalseQuestion")
            {
                TrueFalseQuestionModel tfQuestion = new TrueFalseQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                questionModels.Add(tfQuestion);
            }
            else if(question.QuestionType == "MultipleChoiceQuestion")
            {
                MultipleChoiceQuestionModel multipleChoiceQuestion = new MultipleChoiceQuestionModel();
                multipleChoiceQuestion.ID = question.ID;
                multipleChoiceQuestion.Question = question.Question;
                multipleChoiceQuestion.Choices = question.Choices;
                questionModels.Add(multipleChoiceQuestion);
            }
            else if (question.QuestionType == "ShortAnswerQuestion")
            {
                ShortAnswerQuestionModel shortAnswerQuestion = new ShortAnswerQuestionModel();
                shortAnswerQuestion.ID = question.ID;
                shortAnswerQuestion.Question = question.Question;
                questionModels.Add(shortAnswerQuestion);
            }
            else if (question.QuestionType == "LongAnswerQuestion")
            {
                LongAnswerQuestionModel longAnswerQuestion = new LongAnswerQuestionModel();
                longAnswerQuestion.ID = question.ID;
                longAnswerQuestion.Question = question.Question;
                questionModels.Add(longAnswerQuestion);
            }
            //TODO: Implement creating the rest of the question models here. Multiple choice questions will require setting the choices.
        }
        return questionModels;
    }
}