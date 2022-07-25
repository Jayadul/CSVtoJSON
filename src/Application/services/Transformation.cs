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

        /// <summary>
        /// update key of any dictionary property
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dic"></param>
        /// <param name="fromKey"></param>
        /// <param name="toKey"></param>
        public static void RenameKey<TKey, TValue>(IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey)
        {
            TValue value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }
    }
}

