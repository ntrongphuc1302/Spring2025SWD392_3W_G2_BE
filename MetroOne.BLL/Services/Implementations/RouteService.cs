using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Implementations
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateRouteResponse> CreateRouteAsync(CreateRouteRequest request)
        {
            var startStation = await _unitOfWork.Stations.GetStationByIdAsync(request.StartStationId);
            var startStationName = startStation.StationName;

            // Lấy tên trạm kết thúc
            var endStation = await _unitOfWork.Stations.GetStationByIdAsync(request.EndStationId);
            var endStationName = endStation.StationName;
            var route = new Route
            {
                RouteName = request.RouteName,
                RouteLocationId = request.RouteLocationId,
                StartStationId = request.StartStationId,
                EndStationId = request.EndStationId
            };
            var success = await _unitOfWork.Routes.CreateAsync(route);
            if (!success) 
                throw new Exception("Failed to create route");
            return new CreateRouteResponse
            {
                RouteId = route.RouteId,
                RouteName = route.RouteName,
                RouteLocationId = route.RouteLocationId,
                //StartStationId = route.StartStationId,
                //EndStationId = route.EndStationId,
                StartStationName = startStationName, 
                EndStationName = endStationName
            };
        }

        public async Task<bool> DeleteRouteAsync(int routeId)
        {
            var route = await _unitOfWork.Routes.GetByIdAsync(routeId);
            if (route == null)
                throw new Exception("Route not found");
            return await _unitOfWork.Routes.DeleteAsync(route.RouteId);
        }

        public async Task<List<GetRouteResponse>> GetAllRoutesAsync()
        {
            var routes = await _unitOfWork.Routes.GetAllAsync();

            var routeResponses = new List<GetRouteResponse>();

            foreach (var route in routes)
            {
                // Gọi lấy Station theo Id
                var startStation = await _unitOfWork.Stations.GetStationByIdAsync(route.StartStationId ?? 0);
                var endStation = await _unitOfWork.Stations.GetStationByIdAsync(route.EndStationId ?? 0);

                routeResponses.Add(new GetRouteResponse
                {
                    RouteId = route.RouteId,
                    RouteName = route.RouteName,
                    RouteLocationId = route.RouteLocationId,
                    StartStationName = startStation?.StationName ?? "Unknown",
                    EndStationName = endStation?.StationName ?? "Unknown"
                });
            }

            return routeResponses;
        }


        public async Task<GetRouteResponse> GetRouteByIdAsync(int routeId)
        {
            var route = await _unitOfWork.Routes.GetByIdAsync(routeId);
            if (route == null) return null;

            var startStation = route.StartStationId.HasValue
                ? await _unitOfWork.Stations.GetStationByIdAsync(route.StartStationId.Value)
                : null;

            var endStation = route.EndStationId.HasValue
                ? await _unitOfWork.Stations.GetStationByIdAsync(route.EndStationId.Value)
                : null;

            return new GetRouteResponse
            {
                RouteId = route.RouteId,
                RouteName = route.RouteName,
                RouteLocationId = route.RouteLocationId,
                StartStationName = startStation?.StationName ?? "Unknown",
                EndStationName = endStation?.StationName ?? "Unknown"
            };
        }


        public async Task<bool> UpdateRouteAsync(UpdateRouteRequest request)
        {
            var currentRoute = await _unitOfWork.Routes.GetByIdAsync(request.RouteId);
            if (currentRoute == null) 
                throw new Exception("Route not found");
            currentRoute.StartStationId = request.StartStationId ?? currentRoute.StartStationId;
            currentRoute.EndStationId = request.EndStationId ?? currentRoute.EndStationId;
            currentRoute.RouteName = request.RouteName ?? currentRoute.RouteName;
            currentRoute.RouteLocationId = request.RouteLocationId ?? currentRoute.RouteLocationId;
            return await _unitOfWork.Routes.UpdateAsync(currentRoute);

        }
    }
}
