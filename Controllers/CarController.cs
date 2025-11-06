using Microsoft.AspNetCore.Mvc;
using WebApplication6;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarRepo _carRepo;

        public CarController(CarRepo carRepo)
        {
            _carRepo = carRepo;

        }
        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carRepo.GetAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            var car = _carRepo.Get(id);
            return car;
        }

        // POST api/<CarController>
        [HttpPost]
        public Car Post([FromBody] Car value)
        {
            _carRepo.Create(value);
            return value;

        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public Car Put(int id, [FromBody] Car value)
        {
            _carRepo.Update(id, value);
            return value;

        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            var car = _carRepo.Get(id);
            _carRepo.Remove(id);
            return car;
        }
    }
}
