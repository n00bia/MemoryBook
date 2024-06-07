using MemoryBook.Models;
using MemoryBook.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        public readonly IQueryRepository _queryRepository;
        public QueryController(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<QueryModel>>> GetAll()
        {
            List<QueryModel> queryList = await _queryRepository.GetAll();
            return Ok(queryList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QueryModel>> GetById(int id)
        {
            QueryModel query = await _queryRepository.GetById(id);
            return Ok(query);
        }

        [HttpPost]
        public async Task<ActionResult<QueryModel>> Add([FromBody] QueryModel queryModel)
        {
            QueryModel query = await _queryRepository.Add(queryModel);
            return Ok(query);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<QueryModel>> Update([FromBody] QueryModel queryModel, int id)
        {
            queryModel.Id = id;
            QueryModel query = await _queryRepository.Update(queryModel);
            return Ok(query);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<QueryModel>> DeleteById(int id)
        {
            bool deleted = await _queryRepository.DeleteById(id);
            return Ok(deleted);
        }
    }
}
