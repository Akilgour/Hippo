namespace Hippologamus.Server.Profiles.PerfLogCollectionResponceProfileMapper
{
    public static class SetShowPerviousPageButton
    {
        public static bool Resolve(int paginationCurrentPage) => paginationCurrentPage == 1 ? false : true;
    }
}
