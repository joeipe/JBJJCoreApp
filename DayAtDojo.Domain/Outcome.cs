using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayAtDojo.Domain
{
    public class Outcome : EntityBase
    {
        public string Name { get; set; }
        public List<SparringDetails> SparringDetails { get; set; }
    }
}
