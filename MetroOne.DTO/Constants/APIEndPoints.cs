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
            public const string Create = $"{BaseTrain}/CreateTrain";
            public const string GetAll = $"{BaseTrain}/all";
            public const string GetById = $"{BaseTrain}/GetTrainById/{{id}}";
            public const string GetByName = $"{BaseTrain}/getTrainByName";
            public const string Update = $"{BaseTrain}/UpdateTrain";
            public const string Delete = $"{BaseTrain}/DeleteTrain/{{id}}";
        }
        public static class Stations
        {
            public const string BaseStation = $"{Base}/Station";
            public const string Create = $"{BaseStation}/CreateStation";
            public const string GetAll = $"{BaseStation}/all";
            public const string GetById = $"{BaseStation}/GetStationById/{{id}}";
            public const string GetByName = $"{BaseStation}/GetStationByName";
            public const string Update = $"{BaseStation}/UpdateStation";
            public const string Delete = $"{BaseStation}/DeleteStation/{{id}}";
        }

        public static class Ticket
        {
            public const string BaseTicket = $"{Base}/ticket";
            public const string Create = $"{BaseTicket}/CreateTicket";
            public const string GetAll = $"{BaseTicket}/all";
            public const string GetById = $"{BaseTicket}/GetTicketById/{{id}}";
            public const string Update = $"{BaseTicket}/UpdateTicket";
            public const string Delete = $"{BaseTicket}/DeleteTicket/{{id}}";
        }

        public static class Debug
        {
            public const string CheckDb = $"{Base}/debug/db-check";
        }
    }
}
