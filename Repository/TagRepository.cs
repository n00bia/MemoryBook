using MemoryBook.Data;
using MemoryBook.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryBook.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly MemoryBookContext _dbContext;

        public TagRepository(MemoryBookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TagModel> Add(TagModel tag)
        {
            await _dbContext.Tags.AddAsync(tag);
            _dbContext.SaveChanges();
            return tag;
        }

        public async Task<bool> DeleteById(int id)
        {
            TagModel tagById = await GetById(id);         

            _dbContext.Tags.Remove(tagById);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<List<TagModel>> GetAll()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<TagModel> GetById(int id)
        {
            return await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TagModel> Update(TagModel tag)
        {
            TagModel wantedTag = await GetById(tag.Id);

            wantedTag.Name = tag.Name;
            await _dbContext.SaveChangesAsync();          
            return wantedTag;
        }
    }
}
