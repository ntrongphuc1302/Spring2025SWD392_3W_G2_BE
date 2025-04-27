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

        public static class Locations
        {
            public const string BaseLocation = $"{Base}/Location";
            public const string Create = $"{BaseLocation}/CreateLocation";
            public const string GetAll = $"{BaseLocation}/all";
            public const string GetById = $"{BaseLocation}/GetLocationById/{{id}}";
            public const string GetByName = $"{BaseLocation}/GetLocationByName";
            public const string Update = $"{BaseLocation}/UpdateLocation";
            public const string Delete = $"{BaseLocation}/DeleteLocation/{{id}}";
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

        public static class Trip
        {
            public const string BaseTrip = $"{Base}/trip";
            public const string Create = $"{BaseTrip}/CreateTrip";
            public const string GetAll = $"{BaseTrip}/all";
            public const string GetById = $"{BaseTrip}/GetTripById/{{id}}";
            public const string Update = $"{BaseTrip}/UpdateTrip";
            public const string Delete = $"{BaseTrip}/DeleteTrip/{{id}}";
        }

        public static class Route
        {
            public const string BaseRoute = $"{Base}/route";
            public const string Create = $"{BaseRoute}/CreateRoute";
            public const string GetAll = $"{BaseRoute}/all";
            public const string GetById = $"{BaseRoute}/GetRouteById/{{id}}";
            public const string Update = $"{BaseRoute}/UpdateRoute";
            public const string Delete = $"{BaseRoute}/DeleteRoute/{{id}}";
        }

        public static class RouteLocation
        {
            public const string BaseRouteLocation = $"{Base}/route-location";
            public const string Create = $"{BaseRouteLocation}/CreateRouteLocation";
            public const string GetAll = $"{BaseRouteLocation}/all";
            public const string GetById = $"{BaseRouteLocation}/GetRouteLocationById/{{id}}";
            public const string Update = $"{BaseRouteLocation}/UpdateRouteLocation";
            public const string Delete = $"{BaseRouteLocation}/DeleteRouteLocation/{{id}}";
        }

        public static class Debug
        {
            public const string CheckDb = $"{Base}/debug/db-check";
        }
    }
}
