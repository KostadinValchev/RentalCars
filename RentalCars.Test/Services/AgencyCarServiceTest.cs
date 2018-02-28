namespace RentalCars.Test.Services
{
    using Data;
    using Data.Models;
    using FluentAssertions;
    using RentalCars.Services.Agency.Implementations;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class AgencyCarServiceTest
    {
        const int one = 1;
        const int two = 2;
        const int hundred = 100;
        const int twoHundred = 200;
        const string agencyName = "FakeAgency";
        const string user = "FakeUser";

        private RentalCarsDbContext db;

        public AgencyCarServiceTest()
        {
            Tests.Initialize();
            db = Tests.GetDatabase();
        }

        [Fact]
        public async Task FindShouldReturnResultWithFilter()
        {
            //Arrange
            var fakeCarOne = new Car { Id = one };
            db.AddRange(fakeCarOne);
            await db.SaveChangesAsync();

            var agencyCarService = new AgencyCarService(db);
            //Act
            var result = await agencyCarService.FindByIdAsync(1);

            //Assert
            result
                .Id
                .Should()
                .Be(1);
        }

        [Fact]
        public async Task FindAsyncShouldReturnCorrectAllCarsByFilterAndOrder()
        {
            //Arrange
            var agency = new Agency()
            {
                Id = one,
                Name = agencyName,
                User = new User() { Id = user },
            };

            var fakeCarOne = new Car()
            {
                Id = one,
                Price = hundred,
                Agency = agency,
                City = new City() { Id = one },
            };

            var fakeCarTwo = new Car()
            {
                Id = two,
                Price = twoHundred,
                Agency = agency,
                City = new City() { Id = one },
            };

            this.db.Cars.AddRange(fakeCarOne, fakeCarTwo);
            await this.db.SaveChangesAsync();

            var agencyCarService = new AgencyCarService(db);
            //Act
            var result = await agencyCarService.AllCarsAsync(agencyName);

            //Assert
            result
                .Should()
                .Contain(r => r.Agency.Name == agencyName);

            result.Should().
                Match(r => r.ElementAt(0).Price == hundred);


        }

        [Fact]
        public async Task FindAsyncShouldReturnCorrectAllCarsWhichAreReturnedFromUserByFilterAndOrder()
        {
            //Arrange
            var agency = new Agency()
            {
                Id = one,
                Name = agencyName,
                User = new User() { Id = user },
            };

            var fakeCarOne = new Car()
            {
                Id = one,
                Price = hundred,
                Agency = agency,
                City = new City() { Id = one },
                ReturnDate = DateTime.MinValue,
                IsReserved = true
            };

            var fakeCarTwo = new Car()
            {
                Id = two,
                Price = twoHundred,
                Agency = agency,
                City = new City() { Id = one },
                ReturnDate = DateTime.MaxValue,
                IsReserved = true
            };

            this.db.Cars.AddRange(fakeCarOne, fakeCarTwo);
            await this.db.SaveChangesAsync();

            var agencyCarService = new AgencyCarService(db);

            //Act
            var result = await agencyCarService.AllReturnedCarsAsync(agencyName);
            //Assert

            result
                .Should()
                .Contain(r => r.Agency.Name == agencyName);

            foreach (var car in result)
            {
                car.ReturnDate.Should().BeBefore(DateTime.UtcNow);
                car.IsReserved.Should().Be(true);
            }

            result.Should().BeInAscendingOrder(r => r.Price);
        }
    }
}