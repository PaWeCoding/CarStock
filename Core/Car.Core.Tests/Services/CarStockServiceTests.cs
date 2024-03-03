using Car.Core.Services;
using Car.Infrastructure.Abstractions.Entities;
using Car.Infrastructure.Abstractions.Enums;
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
            var cars = new List<CarBase>
            {
                CreateCar(year: 2018),
                CreateCar(year: 2024)
            };
            _carRepository.GetAll().Returns(cars.AsQueryable());

            // Act
            var carStock = _testee.GetStockOrderedByYearDesc();

            // Assert
            var firstCar = carStock.First();
            var lastCar = carStock.Last();
            Assert.AreEqual(2024, firstCar.Year);
            Assert.AreEqual(2018, lastCar.Year);
        }

        private static FordCar CreateCar(ushort year)
        {
            var tyre = new Tyre(TyreBrands.Pirelli, 55);
            return new FordCar(year, tyre, tyre, tyre, tyre);
        }
    }
}
