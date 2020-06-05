using Hippologamus.Shared.DTO;

namespace Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper
{
    public static class SetPaginationCurrentPageMinusOne
    {
        public static int Resolve(Pagination pagination) => pagination.CurrentPage - 1;
    }
}