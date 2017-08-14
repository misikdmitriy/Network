using System;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    /// <summary>
    /// Communication network
    /// </summary>
    public class Network : IIdentifiable
    {
        public Guid Id { get; }
        /// <summary>
        /// List that contains netwirk structure
        /// </summary>
        public IList<NodesPair> NodesPairs { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Network()
        {
            Id = Guid.NewGuid();
            NodesPairs = new List<NodesPair>();
        }
    }
}
