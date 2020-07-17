using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewjournalApp.Services
{
    public class BatchesService : BaseService
    {

        private readonly BatchesClient client;

        public BatchesService()
        {
            client = new BatchesClient(apiUri, httpClient);
        }

        public async Task<ICollection<BatchDto>> GetBatchesAsync()
        {
            var vm = await client.GetAsync();
            return vm.Batches;
        }
    }
}
