using System;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class Network : IIdentifiable
    {
        public Guid Id { get; }
        public IEnumerable<NodesPair> NodesPairs { get; }

        public Network()
        {
            Id = Guid.NewGuid();
            NodesPairs = new List<NodesPair>();
        }
    }
}
