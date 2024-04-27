namespace PC_Shop.Models.Data;

public interface IEntity
{
    int Id { get; }
    string Name { get; }
    float Price { get; }
}