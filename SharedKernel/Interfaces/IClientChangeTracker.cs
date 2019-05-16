using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Interfaces
{
    public interface IClientChangeTracker
    {
        bool IsDirty { get; set; }
    }
}
