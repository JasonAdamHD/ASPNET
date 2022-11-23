using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class TrueFalseQuestionModel : TestQuestionModel
{
    [Required]
    [RegularExpression("true|false")]
    public override string Answer{get;set;}
}