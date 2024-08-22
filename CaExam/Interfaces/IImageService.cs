
public interface IImageService
{
    Task<string> SavePictureAsync(IFormFile picture);
}