
using Microsoft.EntityFrameworkCore;
using StreamingService.Data;

namespace StreamingService.Repositories;
public class EFRepository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    public EFRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AddDataAsync(T data)
    {
        try
        {
            _context.Set<T>().Add(data);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateDataAsync(T data)
    {
        try
        {
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteDataAsync(int id)
    {
        try
        {
            var D = await GetDataAsync(id);
            _context.Set<T>().Remove(D);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public virtual async Task<T?> GetDataAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetListDataAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

}
