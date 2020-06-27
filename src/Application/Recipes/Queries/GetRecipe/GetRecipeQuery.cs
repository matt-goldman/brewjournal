using brewjournal.Application.Common.Interfaces;
using brewjournal.Application.Recipes.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Recipes.Queries.GetRecipe
{
    public class GetRecipeQuery : IRequest<RecipeVmDto>
    {
        public int Id { get; set; }
    }

    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeVmDto>
    {
        private IApplicationDbContext _context;

        public GetRecipeQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RecipeVmDto> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
