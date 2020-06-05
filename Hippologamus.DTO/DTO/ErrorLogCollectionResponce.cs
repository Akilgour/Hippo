namespace Hippologamus.Shared.DTO
{
    public class ErrorLogCollectionResponce
    {
        public ErrorLogCollection[] Value { get; set; }
        public RootLink[] Links { get; set; }
        public Pagination Pagination { get; set; }
    }
}
