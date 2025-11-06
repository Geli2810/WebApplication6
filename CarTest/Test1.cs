using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication6;

namespace WebApplication6.Tests
{
    [TestClass]
    public sealed class Test1
    {

        [TestClass]
        public class CarRepoTests
        {
            private CarRepo _repo;

            [TestInitialize]
            public void Setup()
            {
                _repo = new CarRepo();
            }

            [TestMethod]
            public void GetAll_ShouldReturnFourCars()
            {
                var cars = _repo.GetAll();
                Assert.AreEqual(4, cars.Count); // ✅
            }

            [TestMethod]
            public void Get_ShouldReturnCarWithCorrectId()
            {
                var car = _repo.Get(2);
                Assert.IsNotNull(car);
                Assert.AreEqual("blue", car.Color);
                Assert.AreEqual(200, car.Speed);
            }

            [TestMethod]
            public void Create_ShouldAddNewCar()
            {
                var newCar = new Car(5, "black", 500);
                _repo.Create(newCar);

                var result = _repo.GetAll();
                Assert.AreEqual(5, result.Count);
                Assert.IsNotNull(_repo.Get(5));
            }

            [TestMethod]
            public void Remove_ShouldRemoveCar()
            {
                _repo.Remove(1);
                var car = _repo.Get(1);
                Assert.IsNull(car);
            }

            [TestMethod]
            public void Update_ShouldChangeCarProperties()
            {
                var updatedCar = new Car(2, "pink", 250);
                _repo.Update(2, updatedCar);

                var car = _repo.Get(2);
                Assert.AreEqual("pink", car.Color);
                Assert.AreEqual(250, car.Speed);
            }



            // ⚠️ TEST 2: Fejler med exception
            [TestMethod]
            public void SetSpeed_TooHigh_ShouldThrowException()
            {
                // Arrange
                var car = _repo.Get(1);

                // Act + Assert (bruger Assert.ThrowsException)
                Assert.ThrowsException<ArgumentException>(() =>
                {
                    car.Speed = 999; // over 300
                });
            }

            // ✅ Eksempel på test der stadig går igennem
            [TestMethod]
            public void SetColor_ValidColor_ShouldWork()
            {
                var car = _repo.Get(1);
                car.Color = "orange";
                Assert.AreEqual("orange", car.Color);
            }

            // 🔴 Eksempel på test der fejler med exception
            [TestMethod]
            public void SetColor_InvalidColor_ShouldThrowException()
            {
                var car = _repo.Get(1);
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    car.Color = "a"; // for kort => kaster
                });
            }
        }
    }
}
