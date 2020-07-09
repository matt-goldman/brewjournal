using AutoMapper;
using AutoMapper.QueryableExtensions;
using brewjournal.Application.Batch.Common;
using brewjournal.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Batch.Queries.GetBatch
{
    public class GetBatchQuery : IRequest<BatchDto>
    {
        public int Id { get; set; }
    }

    public class GetBatchQueryHandler : IRequestHandler<GetBatchQuery, BatchDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetBatchQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BatchDto> Handle(GetBatchQuery request, CancellationToken cancellationToken)
        {
            return await _context.Batches
                .Where(b => b.Id == request.Id)
                .ProjectTo<BatchDto>(_mapper.ConfigurationProvider)
                .SingleAsync(cancellationToken);
        }
    }
}
