using AutoMapper;
using AutoMapper.QueryableExtensions;
using brewjournal.Application.Batch.Common;
using brewjournal.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Batch.Queries.GetAll
{
    public class GetAllBatchQuery : IRequest<BatchListVm>
    {
    }

    public class GetAllBatchQueryHandler : IRequestHandler<GetAllBatchQuery, BatchListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBatchQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<BatchListVm> Handle(GetAllBatchQuery request, CancellationToken cancellationToken)
        {
            var batchList = await _context.Batches
                .ProjectTo<BatchDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BatchListVm
            {
                Batches = batchList
            };
        }
    }
}
