namespace Blobs.Interfaces
{
    using System.Collections.Generic;

    public interface IBlobData
    {
        IEnumerable<IBlob> Blobs { get; }

        void AddBlob(IBlob blob);
    }
}