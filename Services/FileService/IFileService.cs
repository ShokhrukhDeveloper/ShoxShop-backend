namespace ShoxShop.Services.File;
public interface IFileService
{
    ValueTask<string> SaveFile(IFormFile formFile);
    ValueTask<List<string>> SaveFilesList(List<IFormFile> formFiles);
    ValueTask<string> UpdateFile(IFormFile file,string filePath);
    ValueTask<bool> DeleteFile(string filePath);
    ValueTask<List<bool>> DeleteFilesList(List<string> filePath);

}