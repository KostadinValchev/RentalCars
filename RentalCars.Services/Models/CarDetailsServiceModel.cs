﻿namespace RentalCars.Services.Models
{
    using RentalCars.Common.Mapping;
    using RentalCars.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarDetailsServiceModel : IMapFrom<Car>
    {

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public Category Category { get; set; }

        public decimal Price { get; set; }

        public string ImgUrl { get; set; }

        public FuelType FuelType { get; set; }

        public bool IsReserved { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public bool AirConditioner { get; set; }

        public bool Navigation { get; set; }

        public bool Abs { get; set; }

        public bool Asp { get; set; }

        public bool Mp3Player { get; set; }

        public Agency Agency { get; set; }

        public City City { get; set; }
    }
}