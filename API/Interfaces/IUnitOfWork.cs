namespace API.Interfaces;

public interface IUnitOfWork
{
    IMoneyRepository MoneyRepository { get; }
    IUserRepository UserRepository { get; }
    Task<bool> Complete();
}