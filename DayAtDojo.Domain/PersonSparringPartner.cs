using SharedKernel;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayAtDojo.Domain
{
    public class PersonSparringPartner : EntityBase
    {
        public string FullName { get; set; }
        public int Stripe { get; set; }
        public string Grade { get; set; }
    }
}
