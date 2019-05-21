namespace SharedKernel.Interfaces
{
    public interface IClientChangeTracker
    {
        bool IsDirty { get; set; }
    }
}