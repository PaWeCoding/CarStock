using Car.Core.Services;
using Car.Infrastructure.Abstractions.Enums;

namespace Car.Core.Tests.Services
{
    [TestClass]
    public class CarFactoryTests
    {
        private const TyreBrands DefaultTyreBrand = TyreBrands.Pirelli;
        private const ushort DefaultTyrePressurePsi = 55;
        private const ushort DefaultTyreSizeInch = 17;

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
            Assert.AreEqual(DefaultTyreBrand, fordCar.FrontLeftTyre.Brand);
            Assert.AreEqual(DefaultTyreBrand, fordCar.FrontRightTyre.Brand);
            Assert.AreEqual(DefaultTyreBrand, fordCar.RearLeftTyre.Brand);
            Assert.AreEqual(DefaultTyreBrand, fordCar.RearRightTyre.Brand);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_AllTyresHaveCorrectSizeInch()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(DefaultTyreSizeInch, fordCar.FrontLeftTyre.SizeInch);
            Assert.AreEqual(DefaultTyreSizeInch, fordCar.FrontRightTyre.SizeInch);
            Assert.AreEqual(DefaultTyreSizeInch, fordCar.RearLeftTyre.SizeInch);
            Assert.AreEqual(DefaultTyreSizeInch, fordCar.RearRightTyre.SizeInch);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_FrontTyresHaveCorrectPressurePsi()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.FrontRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateFord_DefaultConfig_RearTyresHaveCorrectPressurePsi()
        {
            // Act
            var fordCar = _testee.CreateFord();

            // Assert
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.RearRightTyre.PressurePsi);
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
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.RearRightTyre.PressurePsi);
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
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, fordCar.FrontRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_HasCorrectCarBrand()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.AreEqual(CarBrands.VW, vwCar.Brand);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_HasCorrectMaxSpeedKmh()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.AreEqual(180, vwCar.MaxSpeedKmh);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_YearEqualsCurrentYear()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.AreEqual((ushort)DateTime.Now.Year, vwCar.Year);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_AllTyresInitialized()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.IsNotNull(vwCar.FrontLeftTyre);
            Assert.IsNotNull(vwCar.FrontRightTyre);
            Assert.IsNotNull(vwCar.RearLeftTyre);
            Assert.IsNotNull(vwCar.RearRightTyre);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_AllTyresHaveCorrectBrand()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.AreEqual(DefaultTyreBrand, vwCar.FrontLeftTyre.Brand);
            Assert.AreEqual(DefaultTyreBrand, vwCar.FrontRightTyre.Brand);
            Assert.AreEqual(DefaultTyreBrand, vwCar.RearLeftTyre.Brand);
            Assert.AreEqual(DefaultTyreBrand, vwCar.RearRightTyre.Brand);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_AllTyresHaveCorrectSizeInch()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.AreEqual(DefaultTyreSizeInch, vwCar.FrontLeftTyre.SizeInch);
            Assert.AreEqual(DefaultTyreSizeInch, vwCar.FrontRightTyre.SizeInch);
            Assert.AreEqual(DefaultTyreSizeInch, vwCar.RearLeftTyre.SizeInch);
            Assert.AreEqual(DefaultTyreSizeInch, vwCar.RearRightTyre.SizeInch);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_FrontTyresHaveCorrectPressurePsi()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.FrontRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateVW_DefaultConfig_RearTyresHaveCorrectPressurePsi()
        {
            // Act
            var vwCar = _testee.CreateVW();

            // Assert
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.RearRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateVW_SetYear_HasYearSet()
        {
            // Arrange
            ushort year = 2024;

            // Act
            var vwCar = _testee.CreateVW(config => config.Year = year);

            // Assert
            Assert.AreEqual(year, vwCar.Year);
        }

        [TestMethod]
        public void CreateVW_SetTyreBrand_AllTyresHaveBrandSet()
        {
            // Arrange
            var tyreBrand = TyreBrands.Michelin;

            // Act
            var vwCar = _testee.CreateVW(config => config.TyreConfig.Brand = tyreBrand);

            // Assert
            Assert.AreEqual(tyreBrand, vwCar.FrontLeftTyre.Brand);
            Assert.AreEqual(tyreBrand, vwCar.FrontRightTyre.Brand);
            Assert.AreEqual(tyreBrand, vwCar.RearLeftTyre.Brand);
            Assert.AreEqual(tyreBrand, vwCar.RearRightTyre.Brand);
        }

        [TestMethod]
        public void CreateVW_SetTyreSizeInch_AllTyresHaveSizeInchSet()
        {
            // Arrange
            ushort tyreSizeInch = 15;

            // Act
            var vwCar = _testee.CreateVW(config => config.TyreConfig.SizeInch = tyreSizeInch);

            // Assert
            Assert.AreEqual(tyreSizeInch, vwCar.FrontLeftTyre.SizeInch);
            Assert.AreEqual(tyreSizeInch, vwCar.FrontRightTyre.SizeInch);
            Assert.AreEqual(tyreSizeInch, vwCar.RearLeftTyre.SizeInch);
            Assert.AreEqual(tyreSizeInch, vwCar.RearRightTyre.SizeInch);
        }

        [TestMethod]
        public void CreateVW_SetFrontTyrePressurePsi_FrontTyresHavePressurePsiSet()
        {
            // Arrange
            ushort tyrePressurePsi = 50;

            // Act
            var vwCar = _testee.CreateVW(config => config.TyreConfig.FrontPressurePsi = tyrePressurePsi);

            // Assert
            Assert.AreEqual(tyrePressurePsi, vwCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(tyrePressurePsi, vwCar.FrontRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateVW_SetFrontTyrePressurePsi_RearTyresHaveDefaultPressurePsiSet()
        {
            // Act
            var vwCar = _testee.CreateVW(config => config.TyreConfig.FrontPressurePsi = 50);

            // Assert
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.RearRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateVW_SetRearTyrePressurePsi_RearTyresHavePressurePsiSet()
        {
            // Arrange
            ushort tyrePressurePsi = 50;

            // Act
            var vwCar = _testee.CreateVW(config => config.TyreConfig.RearPressurePsi = tyrePressurePsi);

            // Assert
            Assert.AreEqual(tyrePressurePsi, vwCar.RearLeftTyre.PressurePsi);
            Assert.AreEqual(tyrePressurePsi, vwCar.RearRightTyre.PressurePsi);
        }

        [TestMethod]
        public void CreateVW_SetRearTyrePressurePsi_FrontTyresHaveDefaultPressurePsiSet()
        {
            // Act
            var vwCar = _testee.CreateVW(config => config.TyreConfig.RearPressurePsi = 50);

            // Assert
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.FrontLeftTyre.PressurePsi);
            Assert.AreEqual(DefaultTyrePressurePsi, vwCar.FrontRightTyre.PressurePsi);
        }
    }
}
