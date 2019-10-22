namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        private readonly int _passengersCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            _passengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            return obj is PassengerPlane plane &&
                   base.Equals(obj) &&
                   _passengersCapacity == plane._passengersCapacity;
        }

        public override int GetHashCode()
        {
            const int coefficient = -1521134295;
            return (unchecked(751774561 * coefficient) + base.GetHashCode()) * coefficient + _passengersCapacity.GetHashCode();
        }

        public int GetCapacity()
        {
            return _passengersCapacity;
        }
       
        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", passengersCapacity=" + _passengersCapacity +
                    '}');
        }       
    }
}
