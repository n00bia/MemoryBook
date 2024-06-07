using MemoryBook.Data;
using MemoryBook.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryBook.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly MemoryBookContext _dbContext;

        public QueryRepository(MemoryBookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QueryModel> Add(QueryModel query)
        {
            await _dbContext.Queries.AddAsync(query);
            _dbContext.SaveChanges();

            return query;
        }

        public async Task<bool> DeleteById(int id)
        {
            QueryModel queryById = await GetById(id);

            if (queryById == null)
            {
                throw new Exception("Tag not found");
            }

            _dbContext.Queries.Remove(queryById);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<QueryModel>> GetAll()
        {
            return await _dbContext.Queries.ToListAsync();
        }

        public async Task<QueryModel> GetById(int id)
        {
            return await _dbContext.Queries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<QueryModel> Update(QueryModel query)
        {
            QueryModel wantedQuery = _dbContext.Queries.FirstOrDefault(q => q.Id == query.Id);

            if (wantedQuery == null)
            {
                throw new Exception("Query not found");
            }

            wantedQuery.Body = query.Body;

            _dbContext.Queries.Update(wantedQuery);
            _dbContext.SaveChanges();
            return Task.FromResult(wantedQuery);
        }
    }
}
