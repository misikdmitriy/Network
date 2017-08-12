using System.Linq;
using Network.Business.Commands;
using Network.Business.Services.Interfaces;
using Network.Domain.Entities;

namespace Network.Business.Services
{
    public class CommandCreator : ICommandCreator
    {
        private readonly CommandHandlerService _commandHandlerService;

        public CommandCreator(CommandHandlerService commandHandlerService)
        {
            _commandHandlerService = commandHandlerService;
        }

        public void Accept(Domain.Entities.Network network)
        {
            var channels = network.NodesPairs.Select(n => n.Channel);

            var nodes = network.NodesPairs.Select(n => n.NodeFrom);
            nodes = nodes.Union(network.NodesPairs.Select(n => n.NodeTo));
            nodes = nodes.Distinct();

            foreach (var node in nodes)
            {
                node.MessagesBuffer.OnMessageAdd += added => OnAddMessageToNode(node, added);
            }

            foreach (var channel in channels)
            {
                channel.MessagesBuffer.OnMessageAdd += added => OnAddMessageToChannel(channel, added);
            }
        }

        private void OnAddMessageToChannel(Channel channel, Message added)
        {
            var command = new AddMessageToChannel(channel, added);

            InvokeCommand(command);
        }

        private void OnAddMessageToNode(Node node, Message added)
        {
            var command = new AddMessageToNodeCommand(added, node);

            InvokeCommand(command);
        }

        private void InvokeCommand(Command command)
        {
            _commandHandlerService.GetType()
                .GetMethod("Handle" + command.GetType().Name)
                .Invoke(_commandHandlerService, new object[] { command });
        }
    }
}
