using Hippologamus.Shared.DTO;

namespace Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper
{
    public class SetShowSecondEllipsis
    {
        public static object Resolve(Pagination pagination) => (pagination.TotalPages != pagination.CurrentPage);
    }
}