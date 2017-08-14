using System.Linq;
using Network.Business.Commands;
using Network.Business.Services.Interfaces;
using Network.Domain.Entities;

namespace Network.Business.Services
{
    using Network = Domain.Entities.Network;

    public class CommandCreator : ICommandCreator
    {
        private readonly ICommandHandlerService _commandHandlerService;

        public CommandCreator(ICommandHandlerService commandHandlerService)
        {
            _commandHandlerService = commandHandlerService;
        }

        public void Accept(Network network)
        {
            var channels = network.NodesPairs.Select(n => n.Channel);
            var nodes = network.NodesPairs.SelectMany(n => n.Nodes).Distinct();

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
            var method = _commandHandlerService.GetType()
                .GetMethod("Handle" + command.GetType().Name);

            method.Invoke(_commandHandlerService, new object[] { command });
        }
    }
}
