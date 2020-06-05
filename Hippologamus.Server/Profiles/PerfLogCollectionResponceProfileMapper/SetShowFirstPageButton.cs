using Hippologamus.Shared.DTO;

namespace Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper
{
    public static class SetShowFirstPageButton
    {
        public static bool Resolve(Pagination pagination) => pagination.CurrentPage != 1;
    }
}
