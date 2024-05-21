namespace Persistence.Contract;
public interface IDDDRepository
{
    Task<bool> Exist(int DDD);
}
