using SharedKernel;

namespace Student.Domain
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeId { get; set; }
        public int Stripe { get; set; }
        public Grade Grade { get; set; }
    }
}