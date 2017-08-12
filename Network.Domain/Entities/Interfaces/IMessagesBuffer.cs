using System.Collections.Generic;

namespace Network.Domain.Entities.Interfaces
{
    public delegate void MessageAddedHandler(Message added);
    public delegate void MessageRemovedHandler(Message added);

    public delegate void BufferCleared();

    public interface IMessagesBuffer : IList<Message>
    {
        event MessageAddedHandler OnMessageAdd;
        event MessageRemovedHandler OnMessageRemoved;
        event BufferCleared OnBufferCleared;
    }
}