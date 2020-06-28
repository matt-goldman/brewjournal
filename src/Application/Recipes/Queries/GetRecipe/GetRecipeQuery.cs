using AutoMapper;
using AutoMapper.QueryableExtensions;
using brewjournal.Application.Common.Interfaces;
using brewjournal.Application.Recipes.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Recipes.Queries.GetRecipe
{
    public class GetRecipeQuery : IRequest<RecipeDto>
    {
        public int Id { get; set; }
    }

    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeDto>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public GetRecipeQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecipeDto> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Recipes
                .Where(r => r.Id == request.Id)
                .ProjectTo<RecipeDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return entity;
        }
    }
}
