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

    public async ValueTask<string> SaveFile(IFormFile formFile,string folder)
    {
        var file=formFile.OpenReadStream();
        var path=System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory()));
        string textFile= System.IO.Path.Combine(path,"StaticFiles");
        if(!Path.Exists(textFile))
        {
            System.IO.Directory.CreateDirectory(textFile);
        }
        string folderName=System.IO.Path.Combine(textFile,folder);
        if (!Path.Exists(folderName))
        {
            System.IO.Directory.CreateDirectory(folderName);
        }
        var fileExtension = DefineFileExtension(formFile);
        
        var fileName = DateTime.Now.ToString("yyyy'-'MM'-'dd'-'hh'-'mm'-'ss") + "." + fileExtension;
        string image=System.IO.Path.Combine(folderName,fileName);
        using (Stream fileStream = new FileStream(image, FileMode.Create)) {
                    await file!.CopyToAsync(fileStream);
                }
        Console.WriteLine(image);
        return folder+"/"+fileName;
    }

    public async ValueTask<List<string>> SaveFilesList(List<IFormFile> formFiles,string folder)
    {
        List<string> list=new();
        foreach (var item in formFiles)
        {
            if (FileValidateImage(item))
            {
            string path = await SaveFile(item,folder);
            list.Add(path);
            }
           
        }
        return list;
    }
    // imaga validation
    public bool FileValidateImage(IFormFile file)
    {
        var defineFileExtension = DefineFileExtension(file);

        if ((defineFileExtension.ToLower() == "png" || defineFileExtension.ToLower() == "jpg" || defineFileExtension.ToLower() == "gif" || defineFileExtension.ToLower() == "jpeg"))
            return true;

        return false;
    }

    public ValueTask<string> UpdateFile(IFormFile file, string filePath)
    {
        throw new NotImplementedException();
    }
        private string DefineFileExtension(IFormFile file)
    {
        var reverseFileName = Reverse(file.FileName);
        var count = reverseFileName.Count();
        var index = reverseFileName.IndexOf(".");
        reverseFileName = reverseFileName.Substring(0, index);

        return Reverse(reverseFileName);
    }
        private string Reverse(string fileName)
    {

        char[] charArray = fileName.ToCharArray();
        string reversedString = String.Empty;
        int length, index;
        length = charArray.Length - 1;
        index = length;

        while (index > -1)
        {
            reversedString = reversedString + charArray[index];
            index--;
        }

        return reversedString;
    }
}