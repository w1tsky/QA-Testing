using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private readonly MilitaryType _type;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is MilitaryPlane plane &&
                   base.Equals(obj) &&
                   _type == plane._type;
        }

        public override int GetHashCode()
        {
            const int coefficient = -1521134295;
            return (unchecked(1701194404 * coefficient) + base.GetHashCode()) * coefficient + _type.GetHashCode();
        }

        public MilitaryType GetPlaneType()
        {
            return _type;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + _type +
                    '}');
        }
    }
}
