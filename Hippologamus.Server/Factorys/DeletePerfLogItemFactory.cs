using Hippologamus.Server.Models;

namespace Hippologamus.Server.Factorys
{
    public static class DeletePerfLogItemFactory
    {
        public static DeleteItem Create(string deleteVaule)
        {
            return new DeleteItem()
            {
                CheckValue = deleteVaule,
                DeleteCaption = $"Do you want to delete {deleteVaule}, then type {deleteVaule}.",
                DialogTitle = "Delete Performance Log"
            };
        }
    }
}
