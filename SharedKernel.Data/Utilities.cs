using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedKernel.Interfaces;

namespace SharedKernel.Data
{
    public static class Utilities
    {
        public static void ApplyStateUsingIsKeySet(EntityEntry entry)
        {
            if (entry.IsKeySet)
            {
                if (((IClientChangeTracker)entry.Entity).IsDirty)
                {
                    entry.State = EntityState.Modified;
                }
                else
                {
                    entry.State = EntityState.Unchanged;
                }
            }
            else
            {
                entry.State = EntityState.Added;
            }
        }

        public static void FixState(this DbContext context, IEntity item)
        {
            context.ChangeTracker.TrackGraph(item, e => ApplyStateUsingIsKeySet(e.Entry));
        }
    }
}