using Network.Business.Commands;
using Network.Domain.Entities;

namespace Network.Business.Services
{
    public class CommandCreator
    {
        private CommandHandlerService _commandHandlerService;

        public CommandCreator(CommandHandlerService commandHandlerService)
        {
            _commandHandlerService = commandHandlerService;
        }

        public void Accept(Domain.Entities.Network network)
        {
            foreach (var node in network)
            {
                node.MessagesBuffer.OnMessageAdd += added => OnAddMessage(node, added);
            }
        }

        public void OnAddMessage(Node node, Message message)
        {
            var command = new AddMessageToNodeCommand(message, node);

            _commandHandlerService.GetType()
                .GetMethod("Handle" + typeof(AddMessageToNodeCommand).Name)
                .Invoke(_commandHandlerService, new object[] { command });
        }
    }
}
