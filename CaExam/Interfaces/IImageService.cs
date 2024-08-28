
public interface IImageService
{
    byte[] ImageToByteArray(string imagePath);
    Task<string> SavePictureAsync(IFormFile picture);
}