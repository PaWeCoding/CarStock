using Car.Infrastructure.Abstractions.Entities;
using Car.Infrastructure.Abstractions.Enums;
using Car.Infrastructure.Repositories;

namespace Car.Infrastructure.Tests.Repositories
{
    [TestClass]
    public class CarRepositoryTest
    {
        private CarRepository _testee = null!;

        [TestInitialize]
        public void Setup() =>
            _testee = new CarRepository();

        [TestMethod]
        public void GetAll_InsertNoCar_ReturnsEmptyList()
        {
            // Act
            var cars = _testee.GetAll().ToList();

            // Assert
            Assert.IsTrue(cars.Count == 0);
        }

        [TestMethod]
        public void GetAll_InsertOneCar_ReturnsInsertedCar()
        {
            // Arrange
            var car = CreateCar();
            var carList = new List<CarBase> { car };
            _testee.InsertMany(carList);

            // Act
            var cars = _testee.GetAll().ToList();

            // Assert
            Assert.AreEqual(car, cars.Single());
        }

        [TestMethod]
        public void GetAll_InsertMultipleCars_ReturnValueEvaluatedAfterTermination()
        {
            // Arrange
            var car = CreateCar();
            var carList = new List<CarBase> { car };
            _testee.InsertMany(carList);

            // Act
            var cars = _testee.GetAll();
            _testee.InsertMany(carList); // Add the same car one more time without retrieving the current record set again

            // Assert
            Assert.AreEqual(2, cars.ToList().Count);
        }

        private static FordCar CreateCar()
        {
            var tyre = new Tyre(TyreBrands.Pirelli, 55);
            return new FordCar(default, tyre, tyre, tyre, tyre);
        }
    }
}
