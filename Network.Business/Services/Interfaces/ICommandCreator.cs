namespace Network.Business.Services.Interfaces
{
    public interface ICommandCreator
    {
        void Accept(Domain.Entities.Network network);
    }
}