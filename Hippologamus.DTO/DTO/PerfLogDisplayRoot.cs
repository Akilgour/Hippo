using Hippologamus.DTO.DTO;

public class PerfLogDisplayRoot
{
    public PerfLogDisplay[] Value { get; set; }
    public RootLink[] Links { get; set; }
    public RootPaginationHeader PaginationHeader { get; set; }
}