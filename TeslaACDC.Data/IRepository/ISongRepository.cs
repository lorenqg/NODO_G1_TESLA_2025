using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.IRepository;

public interface ISongRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
  Task<List<TEntity>> SongList();
  Task AddAsync(TEntity song);
}