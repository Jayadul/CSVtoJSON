namespace Application.services
{
    public static class Transformation
    {
        /// <summary>
        /// Replace space with underscore in string value
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSankeCase(string str) => str.Trim().Replace(" ", "_");    
    }
}

