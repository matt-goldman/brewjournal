using brewjournal.Application.Common.Interfaces;
using System;

namespace brewjournal.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
