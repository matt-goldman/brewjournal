using brewjournal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace brewjournal.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<brewjournal.Domain.Entities.Batch> Batches { get; set; }
        DbSet<BatchHopAdditions> BatchHopAdditions { get; set; }
        DbSet<BatchSample> BatchSamples { get; set; }
        DbSet<HopAddition> HopAdditions { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeIngredients> RecipeIngredients { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
