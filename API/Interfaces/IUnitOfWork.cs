namespace API.Interfaces;

public interface IUnitOfWork
{
    IMoneyRepository MoneyRepository { get; }
    Task<bool> Complete();
}