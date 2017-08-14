using System;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    /// <summary>
    /// Network endpoint
    /// </summary>
    public class Node : IIdentifiable
    {
        public Guid Id { get; }
        /// <summary>
        /// Messages waiting for sending
        /// </summary>
        public IMessagesBuffer MessagesBuffer { get; }
        /// <summary>
        /// Received messages buffer
        /// </summary>
        public IMessagesBuffer ReceivedMessages { get; }
        /// <summary>
        /// Is node active (works)
        /// </summary>
        public bool IsUnactive { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Node()
        {
            Id = Guid.NewGuid();
            MessagesBuffer = new MessagesBuffer();
            ReceivedMessages = new MessagesBuffer();
        }

        /// <summary>
        /// Constructor used for tests
        /// </summary>
        /// <param name="messagesBuffer">Messages buffer</param>
        /// <param name="receivedMessages">Received messages</param>
        internal Node(IMessagesBuffer messagesBuffer, IMessagesBuffer receivedMessages)
        {
            Id = Guid.NewGuid();
            MessagesBuffer = messagesBuffer;
            ReceivedMessages = receivedMessages;
        }
    }
}