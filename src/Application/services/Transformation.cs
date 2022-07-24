namespace Application.services
{
    public static class Transformation
    {
        public static string ToSankeCase(string str) => str.Trim().Replace(" ", "_");    
    }
}

