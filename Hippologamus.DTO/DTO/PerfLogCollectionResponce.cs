using Hippologamus.DTO.DTO;

public class PerfLogCollectionResponce
{
    public PerfLogCollection[] Value { get; set; }
    public RootLink[] Links { get; set; }
    public Pagination Pagination { get; set; }
}