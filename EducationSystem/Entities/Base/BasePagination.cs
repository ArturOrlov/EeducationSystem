namespace EducationSystem.Entities.Base;

public class BasePagination
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 15;
    
    public int GetSkip() => (Skip - 1) * Take;
}