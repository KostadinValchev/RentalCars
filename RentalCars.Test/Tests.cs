namespace RentalCars.Test
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Web.Infrastructure.Mapping;
    using System;

    public class Tests
    {
        private static bool testInitialized = false;

        public static void Initialize()
        {
            if (!testInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testInitialized = true;
            }
        }

        public static RentalCarsDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<RentalCarsDbContext>()
                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
                 .Options;

            return new RentalCarsDbContext(dbOptions);
        }
    }
}
