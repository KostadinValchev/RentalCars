namespace RentalCars.Services
{
    using Microsoft.AspNetCore.Http;
    using RentalCars.Data.Models;
    using RentalCars.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IImageService
    {
        Task<Image> CreateImageInDatabaseAsync(ICollection<IFormFile> image);

        Task<ImageServiceModel> AgencyImageByIdAsync(int id);

        Task<ImageServiceModel> CarImageByIdAsync(int id);
    }
}
