namespace EducationSystem.Dto.Material.Test.UserResult;

public class CreateUserTestResultDto
{
    public int UserId { get; set; }
    public int TestId { get; set; }
    
    // public List<TestAnswerResult> TestAnswerResult { get; set; }
    public List<int> SelectedTestAnswerId { get; set; }
}