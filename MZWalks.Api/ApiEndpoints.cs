namespace MZWalks.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Walks
    {
        private const string Base = $"{ApiBase}/walks";
        public const string GetAll = Base;
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:Guid}}";
        public const string Update = $"{Base}/{{id:Guid}}";
        public const string Delete = $"{Base}/{{id:Guid}}";
    }

    public static class Regions
    {
        private const string Base = $"{ApiBase}/regions";
        public const string GetAll = Base;
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:Guid?}}";
        public const string Update = $"{Base}/{{id:Guid}}";
        public const string Delete = $"{Base}/{{id:Guid}}";
    }
}