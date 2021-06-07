namespace Infrastructure.File.Image
{
    public interface IImageStorage
    {
        void Save(ImageSaveRequest request);
    }
}
