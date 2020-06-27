using AutoMapper;
using AutoMapper.QueryableExtensions;
using brewjournal.Application.Common.Interfaces;
using brewjournal.Application.Ingredients.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Ingredients.Queries.GetAllIngredients
{
    public class GetAllIngredientsQuery : IRequest<IngredientsVm>
    {

    }

    public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, IngredientsVm>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public GetAllIngredientsQueryHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IngredientsVm> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            var ingredints = await _context.Ingredients
                .ProjectTo<IngredientDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new IngredientsVm
            {
                Ingredients = ingredints
            };
        }
    }
}
