namespace MedbaseLibrary.Models;

public class Corrections
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string QuestionChild { get; set; } = string.Empty;
    public bool SuggestedAnswer { get; set; }
    public string SuggestedExplanation { get; set; } = string.Empty;
}