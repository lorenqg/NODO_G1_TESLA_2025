using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.IRepository;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.Repository;

public class SongRepository<TId, TEntity> : ISongRepository<TId, TEntity>
where TId : struct 
where TEntity : BaseEntity<TId>
{
  internal NikolaContext _context;
  internal DbSet<TEntity> _dbset;

  public SongRepository(NikolaContext context)
  {
    _context = context;
    _dbset = context.Set<TEntity>();
  }

  public async Task<List<TEntity>> SongList()
  {
    return await _dbset.ToListAsync();
  }

  public async Task AddAsync(TEntity song)
  {
    await _dbset.AddAsync(song);
    await _context.SaveChangesAsync();
  }
}