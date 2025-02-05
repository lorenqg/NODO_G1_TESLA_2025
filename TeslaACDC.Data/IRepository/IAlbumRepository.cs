using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.IRepository;

public interface IAlbumRepository<TId, TEntity>
where TId: struct
where TEntity : BaseEntity<TId>
{
    Task<List<TEntity>> AlbumList();
    Task AddAsync(TEntity album);
    Task<TEntity> FindAsync(TId id);
    Task<TEntity> UpdateAsync(TId id, TEntity album);
    Task<TEntity> DeleteAsync(TId id);
}