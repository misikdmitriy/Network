using Network.Domain.Entities;

namespace Network.Business.Commands
{
    public class AddMessageToNodeCommand : Command
    {
        public Message Message { get; }
        public Node Node { get; }

        public AddMessageToNodeCommand(Message message, Node node)
        {
            Message = message;
            Node = node;
        }
    }
}
