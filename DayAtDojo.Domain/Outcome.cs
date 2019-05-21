using SharedKernel;
using System.Collections.Generic;

namespace DayAtDojo.Domain
{
    public class Outcome : EntityBase
    {
        public string Name { get; set; }
        public List<SparringDetails> SparringDetails { get; set; }
    }
}