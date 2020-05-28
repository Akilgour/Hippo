using Hippologamus.DTO.DTO;

namespace Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper
{
    public static class SetShowSecondPageButton
    {
        public static bool Resolve(Pagination pagination)=> !((pagination.CurrentPage == 1) || (pagination.CurrentPage == 2));
    }
}
