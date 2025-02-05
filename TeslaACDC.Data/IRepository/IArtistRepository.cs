using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.IRepository;

public interface IArtistRepository<TId, TEntity>
where TId: struct
where TEntity : BaseEntity<TId>
{
    Task<List<TEntity>> ArtistList();
    Task AddAsync(TEntity artist);
    Task<TEntity> FindAsync(TId id);
    Task<TEntity> UpdateAsync(TId id, TEntity album);
    Task<TEntity> DeleteAsync(TId id);
}