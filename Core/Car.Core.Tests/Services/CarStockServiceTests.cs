using Car.Core.Services;
using Car.Infrastructure.Abstractions.Entities;
using Car.Infrastructure.Abstractions.Repositories;
using NSubstitute;

namespace Car.Core.Tests.Services
{
    [TestClass]
    public class CarStockServiceTests
    {
        private ICarRepository _carRepository = null!;
        private CarStockService _testee = null!;

        [TestInitialize]
        public void Setup()
        {
            _carRepository = Substitute.For<ICarRepository>();
            _testee = new CarStockService(_carRepository);
        }

        [TestMethod]
        public void GetStockOrderedByYearDesc_InsertCarsWithDifferentYears_ReturnsCarsOrderedByYearDesc()
        {
            // Arrange
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var cars = new List<CarBase>
            {
                new FordCar(2018, default, default, default, default),
                new FordCar(2024, default, default, default, default)
            };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            _carRepository.GetAll().Returns(cars.AsQueryable());

            // Act
            var carStock = _testee.GetStockOrderedByYearDesc();

            // Assert
            var firstCar = carStock.First();
            var lastCar = carStock.Last();
            Assert.AreEqual(2024, firstCar.Year);
            Assert.AreEqual(2018, lastCar.Year);
        }
    }
}
