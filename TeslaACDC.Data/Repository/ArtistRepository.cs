using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.IRepository;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.Repository;

public class ArtistRepository<TId, TEntity> : IArtistRepository<TId, TEntity> where TId : struct
where TEntity : BaseEntity<TId>
{
  private readonly NikolaContext _context;
  internal DbSet<TEntity> _dbset;

  public ArtistRepository(NikolaContext context)
  {
    _context = context;
    _dbset = context.Set<TEntity>();
  }

    public async Task<List<TEntity>> ArtistList()
    {
      return await _dbset.ToListAsync();
    }

    public async Task AddAsync(TEntity artist)
    {
       await _dbset.AddAsync(artist);
       await _context.SaveChangesAsync();
    }

    public async Task<TEntity> FindAsync(TId id)
    {
        return await _dbset.FindAsync(id);
    }

     public async Task<TEntity> UpdateAsync(TId id, TEntity artist)
    {
      var find = await _dbset.FindAsync(id);
      _dbset.Entry(find).CurrentValues.SetValues(artist);
      await _context.SaveChangesAsync();
      return artist;
    }

    public async Task<TEntity> DeleteAsync(TId id)
    {
      var artist = await _dbset.FindAsync(id);
      _dbset.Remove(artist);
      await _context.SaveChangesAsync();
      return artist;
    }
}