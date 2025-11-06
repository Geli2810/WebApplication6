namespace WebApplication6
{
    public class Car
    {
        private int _id;
        private string _color;
        private int _speed;

        public Car(int id, string color, int speed)
        {
            _id = id;
            _color = color;
            _speed = speed;
        }
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id cannot be negative");
                }
                _id = value;
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentNullException("Color cannot be null");
                }
                _color = value;
            }
        }
        public int Speed
        {
            get { return _speed; }
            set
            {
                if (value < 0 || value > 300)
                {
                    throw new ArgumentException("Speed cannot be negative");
                }
                _speed = value;
            }
        }
    }
}
