namespace MetroOne.DTO.Constants
{
    public static class ApiRoutes
    {
        public const string Base = "api";

        public static class Auth
        {
            public const string Login = $"{Base}/auth/login";
            public const string Register = $"{Base}/auth/register";
        }

        public static class Users
        {
            public const string BaseUser = $"{Base}/user";
            public const string Create = $"{Base}/create";
            public const string GetAll = $"{BaseUser}/all";
            public const string GetById = $"{BaseUser}/{{id}}";
            public const string Update = $"{BaseUser}/update";
            public const string Delete = $"{BaseUser}/delete/{{id}}";  
            public const string HardDelete = $"{BaseUser}/delete-hard/{{userId}}";  
        }

        public static class Train
        {
            public const string BaseTrain = $"{Base}/train";
            public const string Create = BaseTrain;
            public const string GetAll = $"{BaseTrain}/all";
            public const string GetById = $"{BaseTrain}/{{id}}";
            public const string Update = $"{BaseTrain}/{{id}}";
            public const string Delete = $"{BaseTrain}/{{id}}";
        }

        public static class Debug
        {
            public const string CheckDb = $"{Base}/debug/db-check";
        }
    }
}
