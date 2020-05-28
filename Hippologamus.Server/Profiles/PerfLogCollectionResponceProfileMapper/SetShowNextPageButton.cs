using Hippologamus.DTO.DTO;

namespace Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper
{
    public static class SetShowNextPageButton
    {
        public static bool Resolve(Pagination pagination) => (pagination.TotalPages != pagination.CurrentPage);
    }
}
