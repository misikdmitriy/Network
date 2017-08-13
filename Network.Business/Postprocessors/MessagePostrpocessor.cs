using System.Linq;
using Network.Domain.Entities;
using Network.Domain.Entities.Interfaces;

namespace Network.Business.Postprocessors
{
    public class MessagePostrpocessor
    {
        public IMessagesBuffer MessagesBuffer { get; }

        public MessagePostrpocessor()
        {
            MessagesBuffer = new UnlimitedMessagesBuffer();
        }

        public void Accept(Domain.Entities.Network network)
        {
            var nodes = network.NodesPairs.Select(n => n.NodeFrom);
            nodes = nodes.Union(network.NodesPairs.Select(n => n.NodeTo));
            nodes = nodes.Distinct();

            foreach (var node in nodes)
            {
                node.ReceivedMessages.OnMessageAdd += added => OnAddMessageToNode(node, added);
            }
        }

        private void OnAddMessageToNode(Node node, Message added)
        {
            node.ReceivedMessages.Remove(added);
            MessagesBuffer.Add(added);
        }
    }
}
