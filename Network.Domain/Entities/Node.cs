using System;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class Node : IIdentifiable
    {
        public Guid Id { get; }
        public IMessagesBuffer MessagesBuffer { get; }
        public IMessagesBuffer ReceivedMessages { get; }
        public bool IsUnactive { get; set; }

        public Node()
        {
            Id = Guid.NewGuid();
            MessagesBuffer = new MessagesBuffer();
            ReceivedMessages = new MessagesBuffer();
        }

        internal Node(IMessagesBuffer messagesBuffer, IMessagesBuffer receivedMessages)
        {
            Id = Guid.NewGuid();
            MessagesBuffer = messagesBuffer;
            ReceivedMessages = receivedMessages;
        }
    }
}