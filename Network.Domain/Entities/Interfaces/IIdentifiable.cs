using System;

namespace Network.Domain.Entities.Interfaces
{
    public interface IIdentifiable
    {
        /// <summary>
        /// Object ID
        /// </summary>
        Guid Id { get; }
    }
}
