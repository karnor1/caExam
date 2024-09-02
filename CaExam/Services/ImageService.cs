
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
    public  byte[] ImageToByteArray(string imagePath)
    {
        byte[] imageBytes = File.ReadAllBytes(_environment.ContentRootPath+imagePath);
        return imageBytes;
    }

    private Bitmap ScaleImage(Stream inputStream, int targetWidth = 200, int targetHeight = 200)
    {
        using (var image = Image.FromStream(inputStream))
        {
            var newImage = new Bitmap(targetWidth, targetHeight, PixelFormat.Format32bppArgb);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                graphics.Clear(Color.Transparent);

                graphics.DrawImage(image, 0, 0, targetWidth, targetHeight);
            }

            return newImage;
        }
    }

    private void SaveImage(Bitmap image, string outputPath, ImageFormat format)
    {
        image.Save(outputPath, format);
    }

    public async Task<string> SavePictureAsync(IFormFile picture)
    {
        var uploadsFolder = Path.Combine(_environment.ContentRootPath, "uploads");
        Directory.CreateDirectory(uploadsFolder);
        var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(picture.FileName)}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var inputStream = picture.OpenReadStream())
        {
            inputStream.Position = 0;  

            Bitmap processedImg = ScaleImage(inputStream);

            SaveImage(processedImg, filePath, ImageFormat.Jpeg); 
        }

        return $"/uploads/{uniqueFileName}";
    }
}


