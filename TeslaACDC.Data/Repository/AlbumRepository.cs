using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.IRepository;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.Repository;

public class AlbumRepository<TId, TEntity> : IAlbumRepository<TId, TEntity> 
where TId : struct
where TEntity : BaseEntity<TId>
{
  private readonly NikolaContext _context;
  internal DbSet<TEntity> _dbset;

  public AlbumRepository(NikolaContext context)
  {
    _context = context;
    _dbset = context.Set<TEntity>();
  }

  public async Task<List<TEntity>> AlbumList()
    {
      return await _dbset.ToListAsync();
    }
    
    public async Task AddAsync(TEntity album)
    {
       await _dbset.AddAsync(album);
       await _context.SaveChangesAsync();
    }
    
    public async Task<TEntity> FindAsync(TId id)
    {
        return await _dbset.FindAsync(id);
    }

    public async Task<TEntity> UpdateAsync(TId id, TEntity album)
    {
      var find = await _dbset.FindAsync(id);
      _dbset.Entry(find).CurrentValues.SetValues(album);
      await _context.SaveChangesAsync();
      return album;
    }

    public async Task<TEntity> DeleteAsync(TId id)
    {
      var album = await _dbset.FindAsync(id);
      _dbset.Remove(album);
      await _context.SaveChangesAsync();
      return album;
    }
}  