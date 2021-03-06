﻿namespace RentalCars.Services.Models
{
    using RentalCars.Common.Mapping;
    using RentalCars.Data.Models;

    public class ImageServiceModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string ContentType { get; set; }
    }
}
