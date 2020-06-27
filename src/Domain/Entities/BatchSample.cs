using System;

namespace brewjournal.Domain.Entities
{
    public class BatchSample
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public DateTime SampleDate { get; set; }
        public long Gravity { get; set; }
        public long Temperature { get; set; }
    }
}
