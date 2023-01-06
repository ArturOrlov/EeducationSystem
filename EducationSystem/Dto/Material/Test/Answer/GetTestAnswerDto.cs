namespace EducationSystem.Dto.Material.Test.Answer;

public class GetTestAnswerDto
{
    public int Id { get; set; }
    public int TestQuestionId { get; set; }
    public string QuestionAnswer { get; set; }
    public bool IsCorrect { get; set; }
}