namespace MZWalks.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Walks
    {
        private const string Base = $"{ApiBase}/walks";
        public const string GetAll = Base;
        public const string Create = Base;
        public const string GetSummary = $"{Base}/summary";
        public const string Get = $"{Base}/{{id}}";
        public const string Update = $"{Base}/{{id}}";
        public const string Delete = $"{Base}/{{id}}";
    }

    public static class Regions
    {
        private const string Base = $"{ApiBase}/regions";
        public const string GetAll = Base;
        public const string Create = Base;
        public const string Get = $"{Base}/{{id}}";
        public const string Update = $"{Base}/{{id}}";
        public const string Delete = $"{Base}/{{id}}";
    }

    public static class Images
    {
        private const string Base = $"{ApiBase}/images";
        public const string Upload = Base;
    }
    public static class Auth
    {
        private const string Base = $"{ApiBase}/auth";
        public const string Register = $"{Base}/register";
        public const string Login = $"{Base}/login";
    }
}