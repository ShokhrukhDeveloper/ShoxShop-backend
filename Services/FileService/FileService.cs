namespace ShoxShop.Services.File;
public class FileService : IFileService
{
    public ValueTask<bool> DeleteFile(string filePath)
    {
        throw new NotImplementedException();
    }

    public ValueTask<List<bool>> DeleteFilesList(List<string> filePath)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<string> SaveFile(IFormFile formFile)
    {
         var file=formFile.OpenReadStream();
        var path=System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory()));
        string textFile= System.IO.Path.Combine(path,"StaticFiles");
        if(!Path.Exists(textFile))
        {
            System.IO.Directory.CreateDirectory(textFile);
        }
        string upload=System.IO.Path.Combine(textFile,"Images");
        if (!Path.Exists(upload))
        {
            System.IO.Directory.CreateDirectory(upload);
        }
       
        string image=System.IO.Path.Combine(upload,"imag1e.jpg");
        using (Stream fileStream = new FileStream(image, FileMode.Create)) {
                    await file!.CopyToAsync(fileStream);
                }
        Console.WriteLine(image);
        return image;
    }

    public ValueTask<List<string>> SaveFilesList(List<IFormFile> formFiles)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string> UpdateFile(IFormFile file, string filePath)
    {
        throw new NotImplementedException();
    }
}