namespace Persistence.Contract;
public interface IDDDRepository
{
    Task<bool> Exists(int DDD);
}
