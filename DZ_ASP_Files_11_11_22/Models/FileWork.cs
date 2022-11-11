using DZ_ASP_Files_11_11_22.Models.Repositorys;

namespace DZ_ASP_Files_11_11_22.Models
{
    public class FileWork
    {
        FileRepos repos;
        public FileRepos Repos
        {
            get
            {
                if (repos == null) repos = new FileRepos();
                return repos;
            }
        }
        public void Dispose() => GC.SuppressFinalize(this);
    }
}
