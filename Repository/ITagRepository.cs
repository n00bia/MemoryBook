using MemoryBook.Models;

namespace MemoryBook.Repository
{
    public interface ITagRepository
    {
        public Task<TagModel> Add(TagModel tag);
        public Task<TagModel> Update(TagModel tag);
        public Task<List<TagModel>> GetAll();
        public Task<TagModel> GetById(int id);
        public Task<bool> DeleteById(int id);
    }
}
