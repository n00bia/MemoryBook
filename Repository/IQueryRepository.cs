using MemoryBook.Models;

namespace MemoryBook.Repository
{
    public interface IQueryRepository
    {
        public Task<QueryModel> Add(QueryModel query);
        public Task<QueryModel> Update(QueryModel query);
        public Task<List<QueryModel>> GetAll();
        public Task<QueryModel> GetById(int id);
        public Task<bool> DeleteById(int id);
    }
}
