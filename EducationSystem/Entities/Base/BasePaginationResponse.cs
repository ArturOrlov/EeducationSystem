namespace EducationSystem.Entities.Base;

public class BasePaginationResponse<T>
{
    public BasePaginationResponse(BasePagination pagination, int totalRecordCount, List<T> records) 
        : this(pagination.Skip, pagination.Take, totalRecordCount, records)
    {
    }

    public BasePaginationResponse(int pageNumber, int pageSize, int totalRecordCount, List<T> records) : this(
        records, totalRecordCount)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    private BasePaginationResponse(List<T> records, int totalRecordCount)
    {
        Records = new List<T>();
        TotalRecordCount = totalRecordCount;
        Records = records;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecordCount { get; set; }
    public List<T> Records { get; set; }

}