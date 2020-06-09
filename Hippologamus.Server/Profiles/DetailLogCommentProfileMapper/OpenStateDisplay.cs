namespace Hippologamus.Server.Profiles.DetailLogCommentProfileMapper
{
    public static class OpenStateDisplay
    {
        public static string Resolve(bool openState) => openState ? "Open" : "Closed";
    }
}
