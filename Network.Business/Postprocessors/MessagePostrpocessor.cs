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
            var nodes = network.NodesPairs.SelectMany(n => n.Nodes).Distinct();

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
