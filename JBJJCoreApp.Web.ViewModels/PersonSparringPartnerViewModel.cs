namespace JBJJCoreApp.Web.ViewModels
{
    public class PersonSparringPartnerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; private set; }
        public int Stripe { get; private set; }
        public string Grade { get; private set; }
    }
}