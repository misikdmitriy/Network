using System;
using Network.Business.Commands;

namespace Network.Business.Services
{
    public class CommandHandlerService
    {
        public void HandleAddMessageToNodeCommand(AddMessageToNodeCommand command)
        {
            if (command.Node.Id == command.Message.Receiver.Id)
            {
                command.Node.MessagesBuffer.Remove(command.Message);
                command.Node.ReceivedMessages.Add(command.Message);
            }
        }

        public void HandleAddMessageToChannelCommand(AddMessageToChannel command)
        {
            throw new NotImplementedException();
        }
    }
}
