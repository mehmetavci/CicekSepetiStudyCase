namespace CicekSepetiStudyCase.Shared.Extensions
{ 
    public static class IsNullExtension
    {

        /// <summary>
        /// checks for not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull<T>(this T obj) where T : class
        {
            return obj != null;
        }


        /// <summary>
        /// cchecks for null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T obj) where T : class
        {
            return obj == null;
        }
    }
}
