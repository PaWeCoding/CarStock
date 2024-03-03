using Car.Core.Services;
using Car.Infrastructure.Abstractions.Enums;

namespace Car.Core.Tests.Services
{
    [TestClass]
    public class CarFactoryTests
    {
        private CarFactory _testee = null!;

        [TestInitialize]
        public void Setup() =>
            _testee = new CarFactory();

        [TestMethod]
        public void CreateFord_DefaultConfig_HasCorrectCarBrand()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(CarBrands.Ford, fordCar.Brand);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_HasCorrectMaxSpeedKmh()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(250, fordCar.MaxSpeedKmh);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_YearEqualsCurrentYear()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual((ushort)DateTime.Now.Year, fordCar.Year);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_AllTyresInitialized()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.IsNotNull(fordCar.FrontLeftTyre);
            Assert.IsNotNull(fordCar.FrontRightTyre);
            Assert.IsNotNull(fordCar.RearLeftTyre);
            Assert.IsNotNull(fordCar.RearRightTyre);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_AllTyresHaveCorrectBrand()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(TyreBrands.Pirelli, fordCar.FrontLeftTyre.Brand);
            Assert.AreEqual(TyreBrands.Pirelli, fordCar.FrontRightTyre.Brand);
            Assert.AreEqual(TyreBrands.Pirelli, fordCar.RearLeftTyre.Brand);
            Assert.AreEqual(TyreBrands.Pirelli, fordCar.RearRightTyre.Brand);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_AllTyresHaveCorrectSizeInch()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(17, fordCar.FrontLeftTyre.SizeInch);
            Assert.AreEqual(17, fordCar.FrontRightTyre.SizeInch);
            Assert.AreEqual(17, fordCar.RearLeftTyre.SizeInch);
            Assert.AreEqual(17, fordCar.RearRightTyre.SizeInch);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_FrontTyresHaveCorrectPressurePsi()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(55, fordCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(55, fordCar.FrontRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_RearTyresHaveCorrectPressurePsi()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(55, fordCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(55, fordCar.RearRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateFord_SetYear_HasYearSet()
        {
            // Arrange
            ushort year = 2024;

            // Act
            var fordCar = _testee.CreateFord(config => config.Year = year);

            // Assert
            Assert.AreEqual(year, fordCar.Year);
        }

        [TestMethod]
        public void CreateFord_SetTyreBrand_AllTyresHaveBrandSet()
        {
            // Arrange
            var tyreBrand = TyreBrands.Michelin;

            // Act
            var fordCar = _testee.CreateFord(config => config.TyreConfig.Brand = tyreBrand);

            // Assert
            Assert.AreEqual(tyreBrand, fordCar.FrontLeftTyre.Brand);
            Assert.AreEqual(tyreBrand, fordCar.FrontRightTyre.Brand);
            Assert.AreEqual(tyreBrand, fordCar.RearLeftTyre.Brand);
            Assert.AreEqual(tyreBrand, fordCar.RearRightTyre.Brand);
        }

        [TestMethod]
        public void CreateFord_SetTyreSizeInch_AllTyresHaveSizeInchSet()
        {
            // Arrange
            ushort tyreSizeInch = 15;

            // Act
            var fordCar = _testee.CreateFord(config => config.TyreConfig.SizeInch = tyreSizeInch);

            // Assert
            Assert.AreEqual(tyreSizeInch, fordCar.FrontLeftTyre.SizeInch);
            Assert.AreEqual(tyreSizeInch, fordCar.FrontRightTyre.SizeInch);
            Assert.AreEqual(tyreSizeInch, fordCar.RearLeftTyre.SizeInch);
            Assert.AreEqual(tyreSizeInch, fordCar.RearRightTyre.SizeInch);
        }

        [TestMethod]
        public void CreateFord_SetFrontTyrePressurePsi_FrontTyresHavePressurePsiSet()
        {
            // Arrange
            ushort tyrePressurePsi = 50;

            // Act
            var fordCar = _testee.CreateFord(config => config.TyreConfig.FrontPressurePsi = tyrePressurePsi);

            // Assert
            Assert.AreEqual(tyrePressurePsi, fordCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(tyrePressurePsi, fordCar.FrontRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateFord_SetFrontTyrePressurePsi_RearTyresHaveDefaultPressurePsiSet()
        {
            // Act
            var fordCar = _testee.CreateFord(config => config.TyreConfig.FrontPressurePsi = 50);

            // Assert
            Assert.AreEqual(55, fordCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(55, fordCar.RearRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateFord_SetRearTyrePressurePsi_RearTyresHavePressurePsiSet()
        {
            // Arrange
            ushort tyrePressurePsi = 50;

            // Act
            var fordCar = _testee.CreateFord(config => config.TyreConfig.RearPressurePsi = tyrePressurePsi);

            // Assert
            Assert.AreEqual(tyrePressurePsi, fordCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(tyrePressurePsi, fordCar.RearRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateFord_SetRearTyrePressurePsi_FrontTyresHaveDefaultPressurePsiSet()
        {
            // Act
            var fordCar = _testee.CreateFord(config => config.TyreConfig.RearPressurePsi = 50);

            // Assert
            Assert.AreEqual(55, fordCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(55, fordCar.FrontRightTyre.PressurePsi);
        }
    }
}
