using Car.Core.Services;
using Car.Infrastructure.Abstractions.Entities;
using Car.Infrastructure.Abstractions.Enums;
using Car.Infrastructure.Repositories;

var carRepository = new CarRepository();
var carStockService = new CarStockService(carRepository);

var carFactory = new CarFactory();

var random = new Random();
var carCount = random.Next(5, 11); // 5 <= carCount <= 10

var cars =
    Enumerable.Range(0, carCount)
        .Select(_ =>
        {
            var carBrand = (CarBrands)random.Next(0, 2);
            var car = CreateCar(carBrand);
            return car;
        });

carStockService.BookInMany(cars);
var carStock = 
    carStockService.GetStockOrderedByYearDesc()
        .Select(c => $"{c.Brand},\t{c.Year},\t{c.MaxSpeedKmh}km/h")
        .ToList();
Console.WriteLine("Brand\tYear\tMax Speed");
carStock.ForEach(Console.WriteLine);

// Assumption: Since the tyre information is currently not used, I have decided to go with the default config for all tyres
CarBase CreateCar(CarBrands carBrands) =>
    carBrands switch
    { 
        CarBrands.Ford => 
            carFactory.CreateFord(config =>
            {
                config.Year = CalculateYear();
            }),
        CarBrands.VW =>
            carFactory.CreateVW(config =>
            {
                config.Year = CalculateYear();
            }),
        _ => throw new ArgumentException("Invalid enum value", nameof(carBrands))
    };

ushort CalculateYear()
{
    var year = random.Next(1980, DateTime.Now.Year + 1); // 1980 <= year <= Current Year
    return (ushort)year;
}