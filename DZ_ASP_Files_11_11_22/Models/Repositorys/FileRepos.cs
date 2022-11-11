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
        public IEnumerable<string> GetFilesNames() => new DirectoryInfo(path).GetFiles().Select(f => f.Name);
        public IEnumerable<string> GetFilesNamesByDate(DateTime date) => new DirectoryInfo(path).GetFiles()
            .Where(f => f.LastWriteTime.ToShortDateString()== date.ToShortDateString()).Select(f => f.Name);




        public async Task<HttpStatusCode> AddFile(IFormFile file)
        {
            if(file.Length > 0)
            {
                string filePath = path + file.FileName;
                int counter = 0;
                while (File.Exists(filePath))
                {
                    counter++;
                    filePath = path + $"({counter})" +  file.FileName;
                }
                using (var stream = File.Create(filePath)) { await file.CopyToAsync(stream);}
                return HttpStatusCode.Created;
            }
            return HttpStatusCode.BadRequest;
        }
    }
}
