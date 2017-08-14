using System;
using System.Collections;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    /// <summary>
    /// Channel that connect two nodes
    /// </summary>
    public class Channel : IIdentifiable, IEnumerable<Message>
    {
        public Guid Id { get; }
        /// <summary>
        /// Channel buffer
        /// </summary>
        public IMessagesBuffer MessagesBuffer { get; set; }
        /// <summary>
        /// Indicates is channel busy
        /// </summary>
        public bool IsBusy => MessagesBuffer.IsFilled;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Channel()
        {
            Id = Guid.NewGuid();
            MessagesBuffer = new MessagesBuffer();
        }

        /// <summary>
        /// Constructor for channel with limited messages buffer
        /// </summary>
        /// <param name="messagesCount">Buffer size</param>
        public Channel(int messagesCount)
        {
            Id = Guid.NewGuid();
            MessagesBuffer = new MessagesBuffer(messagesCount);
        }

        /// <summary>
        /// Constructor for test purposes
        /// </summary>
        /// <param name="messagesBuffer">Buffer</param>
        internal Channel(IMessagesBuffer messagesBuffer)
        {
            Id = Guid.NewGuid();
            MessagesBuffer = messagesBuffer;
        }

        public IEnumerator<Message> GetEnumerator()
        {
            return MessagesBuffer.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
