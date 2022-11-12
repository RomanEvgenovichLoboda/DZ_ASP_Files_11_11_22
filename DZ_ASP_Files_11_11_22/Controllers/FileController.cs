using DZ_ASP_Files_11_11_22.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace DZ_ASP_Files_11_11_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController:Controller
    {
        FileWork fw = new FileWork();
        [HttpGet("GetFilesNames")]
        public IEnumerable<string> GetNames() => fw.Repos.GetFilesNames();
        [HttpGet("GetFilesNamesByDate")]
        public IEnumerable<string> GetNamesByDate(DateTime date) => fw.Repos.GetFilesNamesByDate(date);
        [HttpGet("GetFileBytesByName")]
        public byte[] GetFileBytesByName(string name) => fw.Repos.GetFileBytes(name);
        [HttpGet("DownloadFileByName")]
        public IActionResult DownloadFile(string name)
        {
            var net = new WebClient();
            var data = net.DownloadData(Directory.GetCurrentDirectory() + "/MyFiles/"+name);
            var content = new MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = name;
            return File(content,contentType,fileName);
        }
        [HttpPost("PostFile")]
        public Task<HttpStatusCode> OnPostUploadAsync(IFormFile file) => fw.Repos.AddFile(file);
    }
}
