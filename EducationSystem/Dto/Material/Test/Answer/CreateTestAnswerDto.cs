namespace EducationSystem.Dto.Material.Test.Answer;

public class CreateTestAnswerDto
{
    public int TestQuestionId { get; set; }
    public string QuestionAnswer { get; set; }
    public bool IsCorrect { get; set; }
}