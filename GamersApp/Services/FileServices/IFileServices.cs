using GamersApp.DTO;

namespace GamersApp.Services.FileServices
{
    public interface IFileServices
    {
        Task<String> UploadFileAsync(FileModel fileData);
    }
}
