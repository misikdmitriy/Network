using Network.Business.Commands;

namespace Network.Business.Services
{
    public class CommandHandlerService
    {
        public void HandleAddMessageToNodeCommand(Command command)
        {
            var addMessageCommand = (AddMessageToNodeCommand)command;

            if (addMessageCommand.Node.Id == addMessageCommand.Message.Receiver.Id)
            {
                // TODO: notify
            }
        }
    }
}
