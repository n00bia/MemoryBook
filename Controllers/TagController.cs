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
            TagModel wantedTag = await _tagRepository.GetById(id);

            if (wantedTag == null) 
            {
                return BadRequest("Tag não encontrada");
            }

            wantedTag.Name = tagModel.Name;            
            wantedTag = await _tagRepository.Update(tagModel);
            return Ok(wantedTag);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TagModel>> DeleteById(int id)
        {
            TagModel wantedTag = await _tagRepository.GetById(id);

            if (wantedTag == null)
            {
                return BadRequest("Tag não encontrada.");
            }

            bool deleted = await _tagRepository.DeleteById(id);
            return Ok(deleted);
        }
    }
}
