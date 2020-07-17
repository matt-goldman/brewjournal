using BrewjournalApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace BrewjournalApp.ViewModels
{
    public class BatchesViewModel : BaseViewModel
    {
        private readonly BatchesService _service;

        public ObservableCollection<BatchDto> Batches { get; set; } = new ObservableCollection<BatchDto>();

        public BatchesViewModel()
        {
            _service = new BatchesService();
            _ = Init();
        }

        private async Task Init()
        {
            var batches = await _service.GetBatchesAsync();
            batches.ForEach(batch =>
            {
                Batches.Add(batch);
            });
        }
    }
}
