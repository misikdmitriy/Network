using System;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class Node : IIdentifiable
    {
        public Guid Id { get; }
        public IMessagesBuffer MessagesBuffer { get; }
        public bool IsUnactive { get; set; }

        public Node()
        {
            Id = Guid.NewGuid();
            MessagesBuffer = new UnlimitedMessagesBuffer();
        }
    }
}