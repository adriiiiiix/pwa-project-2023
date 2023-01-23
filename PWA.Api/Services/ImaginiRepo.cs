using Microsoft.EntityFrameworkCore;
using PWA.Api.Data;
using PWA.Api.Data.Models;

namespace PWA.Api.Services
{
    public sealed class ImaginiRepo
    {
        private readonly AppDbContext _context;

        public ImaginiRepo(AppDbContext context)
        {
            _context= context;
        }

        public async Task<Imagine?> GetImagineAsync(int id)
        {
            var imagine = await _context.Imagini.FirstOrDefaultAsync(c => c.Id == id);
            return imagine;
        }

        public async Task AddImagineAsync(Imagine imagine)
        {
            _context.Imagini.Add(imagine);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateImagineAsync(Imagine imagine)
        {
            _context.Imagini.Update(imagine);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveImagineAsync(int id)
        {
            var imagine = await GetImagineAsync(id);
            _context.Imagini.Remove(imagine);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Imagine>> GetAll()
        {
            List<Imagine> cladiri = await _context.Imagini.ToListAsync();
            return cladiri;
        }

    }
}
