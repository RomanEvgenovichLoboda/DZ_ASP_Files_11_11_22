using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DZ_ASP_Files_11_11_22.Models.Repositorys
{
    public class FileRepos
    {
        string path = Directory.GetCurrentDirectory() + "/MyFiles/";
        public FileRepos()
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        public async Task<HttpStatusCode> AddFile(IFormFile file)
        {
            if(file.Length > 0)
            {
                var filePath = path + Path.GetRandomFileName() + "_" + file.FileName;
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return HttpStatusCode.Created;
            }
            return HttpStatusCode.BadRequest;
        }
        public IEnumerable<string> GetFilesNames()
        {
            return new DirectoryInfo(path).GetFiles().Select(f => f.Name);
        }
    }
}
