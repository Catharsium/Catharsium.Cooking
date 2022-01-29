using Catharsium.Util.IO.Files.Interfaces;
namespace Catharsium.Cooking.Data;

public class FileSystemRepository<T>
{
    private readonly IJsonFileRepository<T> jsonFileRepository;


    public FileSystemRepository(IJsonFileRepository<T> jsonFileRepository)
    {
        this.jsonFileRepository = jsonFileRepository;
    }


    //public async Task<List<T>> GetAll()
    //{
    //    return (await this.jsonFileRepository.LoadAll()).ToList();
    //}


    //public async Task Add(T item)
    //{
    //    await this.jsonFileRepository.
    //}
}