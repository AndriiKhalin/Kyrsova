namespace PC_Shop.Interfaces;

public interface IUnitRepository
{
    Task<IEnumerable<Unit>> GetAll();

    Task<Unit> GetById(int id);

    Task<Unit> GetByName(string name);

    Task Add(Unit unit);

    Task Update(Unit unit);

    Task Delete(int id);

}