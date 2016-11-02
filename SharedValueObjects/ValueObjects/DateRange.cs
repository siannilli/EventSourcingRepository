﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomainsObjects.ValueObjects
{
    public class DateRange : BaseValueObject<DateRange>
    {

        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public TimeSpan Interval
        {
            get { return To - From; }
        }

        public DateRange(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
        public override string ToString()
        {
            return $"{this.From} - {this.To}";
        }
    }
}
