using brewjournal.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Recipes.Commands.AddRecipe
{
    public class AddRecipeCommand : IRequest<int>
    {
    }

    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, int>
    {
        public IApplicationDbContext _context;

        public AddRecipeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
