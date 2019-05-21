using SharedKernel.Interfaces;

namespace JBJJCoreApp.Web.ViewModels
{
    public abstract class VMBase : IEntity, IClientChangeTracker
    {
        public int Id { get; set; }
        public bool IsDirty { get; set; }
    }
}