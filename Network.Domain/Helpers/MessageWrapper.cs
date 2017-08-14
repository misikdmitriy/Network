using Network.Domain.Entities;
using Network.Domain.Helpers.Interfaces;

namespace Network.Domain.Helpers
{
    public class MessageWrapper : IWrapper<Message>
    {
        private Message _message;

        public int SendSize { get; private set; }
        public bool IsSent => SendSize >= _message.Size;

        public MessageWrapper(Message message)
        {
            Wrap(message);
        }

        public Message Unwrap()
        {
            return _message;
        }

        public void Wrap(Message wrapped)
        {
            _message = wrapped;
        }

        public void LoadMore(int size)
        {
            SendSize += size;
        }
    }
}
