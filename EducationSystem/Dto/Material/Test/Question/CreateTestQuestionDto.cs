namespace EducationSystem.Dto.Material.Test.Question;

public class CreateTestQuestionDto
{
    public int TestId { get; set; }
    public string QuestionDescription { get; set; }
    public IFormFile? Image { get; set; }
}