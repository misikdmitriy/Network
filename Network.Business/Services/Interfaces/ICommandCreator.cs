namespace Network.Business.Services.Interfaces
{
    using Network = Domain.Entities.Network;

    public interface ICommandCreator
    {
        void Accept(Network network);
    }
}