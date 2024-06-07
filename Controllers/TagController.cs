using MemoryBook.Models;
using MemoryBook.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        public readonly ITagRepository _tagRepository;
        public TagController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TagModel>>> GetAll()
        {
            List<TagModel> tagList = await _tagRepository.GetAll();
            return Ok(tagList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagModel>> GetById(int id)
        {
            TagModel tag = await _tagRepository.GetById(id);
            return Ok(tag);
        }

        [HttpPost]
        public async Task<ActionResult<TagModel>> Add([FromBody] TagModel tagModel)
        {
            TagModel tag = await _tagRepository.Add(tagModel);
            return Ok(tag);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TagModel>> Update([FromBody] TagModel tagModel, int id)
        {
            tagModel.Id = id;
            TagModel tag = await _tagRepository.Update(tagModel);
            return Ok(tag);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TagModel>> DeleteById(int id)
        {
            bool deleted = await _tagRepository.DeleteById(id);
            return Ok(deleted);
        }
    }
}
