using System.Xml.Linq;
using WebApplication6;

namespace WebApplication6
{
    public class CarRepo
    {
        private int _nextid;
        private List<Car> _cars = new List<Car>();

        public CarRepo()
        {
            _cars = new List<Car>()
            {
                new Car(1, "red", 100),
                new Car(2, "blue", 200),
                new Car(3, "green", 300),
                new Car(4, "yellow", 400)

            };

        }

        public Car Create(Car car)
        {

            _cars.Add(car);
            return car;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car? Get(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public Car Remove(int id)
        {
            var car = Get(id);
            _cars.Remove(car);
            return car;
        }

        public Car Update(int id, Car car)
        {
            var existing = Get(id);
            if (existing != null)
            {
                existing.Color = car.Color;
                existing.Speed = car.Speed;
            }

            return car;
        }

    }
}
