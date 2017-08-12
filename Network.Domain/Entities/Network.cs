using System;
using System.Collections;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class Network : IIdentifiable, IEnumerable<Node>
    {
        public Guid Id { get; }
        public IEnumerable<Node> Nodes { get; }

        public Network()
        {
            Nodes = new List<Node>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return Nodes.GetEnumerator();
        }
    }
}
