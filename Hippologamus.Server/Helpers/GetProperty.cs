namespace Hippologamus.Server.Helpers
{
    public static class GetProperty
    {
        public static object Value(object model, string propertyName)
        {
            return model.GetType().GetProperty(propertyName).GetValue(model, null);
        }
    }
}
