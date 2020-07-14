using brewjournal.Application.Batch.Commands.AddBatch;
using brewjournal.Application.Batch.Commands.AddBatchSample;
using brewjournal.Application.Batch.Common;
using brewjournal.Application.Batch.Queries.GetAll;
using brewjournal.Application.Batch.Queries.GetBatch;
using brewjournal.Application.Batch.Queries.Search;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace brewjournal.WebUI.Controllers
{
    public class BatchesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]BatchDto batch)
        {
            return await Mediator.Send(new AddBatchCommand { Batch = batch } );
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Sample (SampleDto sample)
        {
            return await Mediator.Send(new AddBatchSampleCommand { Sample = sample });
        }

        [HttpGet]
        public async Task<ActionResult<BatchListVm>> Get()
        {
            return await Mediator.Send(new GetAllBatchQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatchDto>> Get(int id)
        {
            return await Mediator.Send(new GetBatchQuery { Id = id });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<BatchListVm>> Search(SearchBatchQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
