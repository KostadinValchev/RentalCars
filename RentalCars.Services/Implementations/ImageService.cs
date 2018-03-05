namespace RentalCars.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using RentalCars.Data;
    using RentalCars.Data.Models;
    using RentalCars.Services.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ImageService : IImageService
    {
        private readonly RentalCarsDbContext db;

        public ImageService(RentalCarsDbContext db)
        {
            this.db = db;

        }

        public async Task<ImageServiceModel> AgencyImageByIdAsync(int id)
       => await this.db
              .Images
              .Where(i => i.AgencyId == id)
              .ProjectTo<ImageServiceModel>()
          .FirstOrDefaultAsync();



        public async Task<Image> CreateImageInDatabaseAsync(ICollection<IFormFile> file)
        {
            IFormFile uploadedImage = file.FirstOrDefault();

            var imageEntity = new Image();

            if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    uploadedImage.OpenReadStream().CopyTo(ms);

                    var image = System.Drawing.Image.FromStream(ms);

                    imageEntity.Name = uploadedImage.Name;
                    imageEntity.Data = ms.ToArray();
                    imageEntity.Width = image.Width;
                    imageEntity.Height = image.Height;
                    imageEntity.ContentType = uploadedImage.ContentType;

                    this.db.Images.Add(imageEntity);
                    await this.db.SaveChangesAsync();
                }
            }
            return imageEntity;
        }
    }
}
