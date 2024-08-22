
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

public class ImageService : IImageService
{
    private readonly IWebHostEnvironment _environment;

    public ImageService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    private void ScaleImage(Stream inputStream, Stream outputStream, int maxWidth, int maxHeight)
    {
        using (var image = Image.FromStream(inputStream))
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            using (var newImage = new Bitmap(newWidth, newHeight))
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                newImage.Save(outputStream, ImageFormat.Jpeg);
            }
        }
    }

    public async Task<string> SavePictureAsync(IFormFile picture)
    {
        var uploadsFolder = Path.Combine(_environment.ContentRootPath, "PictureUploads");
        Directory.CreateDirectory(uploadsFolder);
        var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(picture.FileName)}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var inputStream = picture.OpenReadStream())
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            // Scale image and save to file
            ScaleImage(inputStream, fileStream, 200, 200);
        }

        return $"/uploads/{uniqueFileName}";
    }
}


