using Network.Business.Commands;

namespace Network.Business.Services.Interfaces
{
    public interface ICommandHandlerService
    {
        void HandleAddMessageToChannelCommand(AddMessageToChannel command);
        void HandleAddMessageToNodeCommand(AddMessageToNodeCommand command);
    }
}