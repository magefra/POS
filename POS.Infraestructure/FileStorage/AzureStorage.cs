using Microsoft.AspNetCore.Http;

namespace POS.Infraestructure.FileStorage
{
    public class AzureStorage : IAzureStorage
    {


        public Task<string> EditFile(string container, IFormFile file, string route)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveFile(string route, string container)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(string container, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
