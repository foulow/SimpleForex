namespace SimpleForex.Core.Collections
{
    /// <summary>
    /// Contains a list of regular expressions for data validation.
    /// </summary>
    public static class Regexs
    {
        /// <summary>
        /// Contains the regular expression to validate a User's Id that should only have alphanumeric characters.
        /// Source: https://stackoverflow.com/questions/4902749/create-one-regex-to-validate-a-username
        /// </summary>
        public static readonly string UserIdRegex = @"^[a-zA-Z][a-zA-Z0-9._-]{0,25}([-.][^_]|[^-.]{2})$";

        /// <summary>
        /// Contains the regular expression to validate a URL selected base on tests coverage.
        /// Source: https://mathiasbynens.be/demo/url-regex
        /// and: https://stackoverflow.com/questions/5717312/regular-expression-for-url
        /// </summary>
        public static readonly string URLRegex = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
    }
}
