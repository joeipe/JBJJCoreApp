using SharedKernel.Interfaces;

namespace SharedKernel
{
    public abstract class EntityBase : IEntity, IClientChangeTracker
    {
        public int Id { get; set; }
        public bool IsDirty { get; set; }
    }
}