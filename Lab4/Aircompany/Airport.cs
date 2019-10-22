using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private readonly List<Plane> _planes;

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public IEnumerable<PassengerPlane> GetPassengerPlanes()
        {
            return _planes.Where(plane => plane.GetType() == typeof(PassengerPlane)).Cast<PassengerPlane>();
        }

        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.Where(plane => plane.GetType() == typeof(MilitaryPlane)).Cast<MilitaryPlane>();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            var passengerPlanes = GetPassengerPlanes();
            return passengerPlanes.Aggregate((passengerPlane, plane) =>
                passengerPlane.GetCapacity() > plane.GetCapacity()
                    ? passengerPlane
                    : plane);
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            var militaryPlanes = GetMilitaryPlanes();
            return militaryPlanes.Where(plane => plane.GetPlaneType() == MilitaryType.Transport);
        }

        public Airport GetAirportWithSortedPlanesByMaxFlightDistance()
        {
            return new Airport(_planes.OrderBy(plane => plane.GetMaxFlightDistance()));
        }

        public Airport GetAirportWithSortedPlanesByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(plane => plane.GetMaxSpeed()));
        }

        public Airport GetAirportWithSortedPlanesByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(plane => plane.GetMaxLoadCapacity()));
        }

        public IEnumerable<Plane> GetPlanes()
        {
            return _planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", _planes.Select(plane => plane.GetModel())) +
                    '}';
        }
    }
}
