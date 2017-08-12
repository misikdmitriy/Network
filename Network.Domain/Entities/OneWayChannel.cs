using System;
using System.Collections;
using System.Collections.Generic;
using Network.Domain.Entities.Interfaces;

namespace Network.Domain.Entities
{
    public class OneWayChannel : IIdentifiable, IChannel
    {
        public Guid Id { get; }
        public IMessagesBuffer MessagesBuffer { get; set; }

        public OneWayChannel()
        {
            MessagesBuffer = new LimitedMessageBuffer(1);
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
