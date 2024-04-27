namespace PC_Shop.Interfaces;

public interface IVideoCardRepository
{
    Task<IEnumerable<VideoCard>> GetAll();

    Task<VideoCard> GetById(int id);

    Task<VideoCard> GetByName(string name);

    Task Add(VideoCard videoCard);

    Task Update(VideoCard videoCard);

    Task Delete(int id);

}