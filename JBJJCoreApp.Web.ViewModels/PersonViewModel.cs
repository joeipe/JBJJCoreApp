using System;
using System.Collections.Generic;
using System.Text;

namespace JBJJCoreApp.Web.ViewModels
{
    public class PersonViewModel : VMBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeId { get; set; }
        public int Stripe { get; set; }
        public GradeViewModel Grade { get; set; }
        public List<SparringDetailsViewModel> SparringDetails { get; set; }
    }
}
