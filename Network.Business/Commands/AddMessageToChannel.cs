using Network.Domain.Entities;

namespace Network.Business.Commands
{
    public class AddMessageToChannel : Command
    {
        public Channel Channel { get; }
        public Message Message { get; }

        public AddMessageToChannel(Channel channel, Message message)
        {
            Channel = channel;
            Message = message;
        }
    }
}
