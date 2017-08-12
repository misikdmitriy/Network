using System;

namespace Network.Domain.Entities.Interfaces
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
