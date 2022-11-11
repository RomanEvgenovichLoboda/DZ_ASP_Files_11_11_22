using DZ_ASP_Files_11_11_22.Models;
using DZ_ASP_Files_11_11_22.Models.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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


        [HttpPost("PostFile")]
        public Task<HttpStatusCode> OnPostUploadAsync(IFormFile file) => fw.Repos.AddFile(file);
    }
}
