using Hippologamus.Shared.DTO;

namespace Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper
{
    public static class SetShowPagePlusOneButton
    {
        public static bool Resolve(Pagination pagination) =>
            !((pagination.CurrentPage == pagination.TotalPages) ||
            (pagination.CurrentPage == (pagination.TotalPages - 1)));
    }
}