using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Storage
{
    public interface IStorage
    {
        Task<T> Store<T>(IFormFile file) where T : File, new();
    }
}