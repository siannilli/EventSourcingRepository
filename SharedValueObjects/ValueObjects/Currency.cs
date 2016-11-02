﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomainsObjects.ValueObjects
{
    public class Currency: BaseValueObject<Currency>
    {
        public string Code { get; private set; }
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public Currency(string code, string name, string symbol)
        {
            this.Code = code;
            this.Name = name;
            this.Symbol = symbol;
        }

        public override string ToString()
        {
            return $"[{this.Symbol ?? this.Code}]\t{this.Name}";
        }
    }
}
