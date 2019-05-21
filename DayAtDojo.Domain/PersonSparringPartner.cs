using SharedKernel.Interfaces;

namespace DayAtDojo.Domain
{
    public class PersonSparringPartner : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Stripe { get; set; }
        public string Grade { get; set; }
    }
}