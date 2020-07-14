using brewjournal.Application.Common.Mappings;
using brewjournal.Domain.Entities;
using System;

namespace brewjournal.Application.Batch.Common
{
    public class SampleDto : IMapFrom<BatchSample>
    {
        public int BatchId { get; set; }
        public DateTime SampleDate { get; set; }
        public float? Gravity { get; set; }
        public long? Temperature { get; set; }
    }
}
