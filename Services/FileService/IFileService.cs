namespace ShoxShop.Services.File;
public interface IFileService
{
    ValueTask<string> SaveFile(IFormFile formFile,string folder);
    ValueTask<List<string>> SaveFilesList(List<IFormFile> formFiles,string folder);
    ValueTask<string> UpdateFile(IFormFile file,string folder,string filePath);
    ValueTask<bool> DeleteFile(string filePath);
    ValueTask<List<bool>> DeleteFilesList(List<string> filePath);

}