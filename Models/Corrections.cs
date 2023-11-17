namespace MedbaseLibrary.Models;

public class Corrections
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public bool SuggestedAnswer { get; set; }
    public string QuestionChild { get; set; } = string.Empty;
    public string SuggestedExplanation { get; set; } = string.Empty;
    public bool Merged { get; set; } = false;
    public DateTime DateOfCorrection { get; set; } = DateTime.Now;
    public Guid CorrectionAuthor { get; set; } = Guid.Empty;
}

public class CorrectionCommunityDto
{
    public User User { get; set; } = new();
    public int NumberOfCorrections { get; set; }
}