using UserPostApi.Models;
using Microsoft.EntityFrameworkCore;
using UserPostApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserPostApi.Services
{
    public class ProviderService : IProviderService
    {
        private readonly DataBaseContext _context;

        public ProviderService(DataBaseContext context) {
            _context = context;
        }

        public Provider? GetProvider(int id) {
            return _context.Providers.Find(id);
        }

        public IEnumerable<Provider> GetAllProviders() {
            return _context.Providers.ToList();
        }

        public void AddProvider(Provider provider) {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

        public void UpdateProvider(Provider provider) {
            _context.Entry(provider).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProvider(int id) {
            var provider = _context.Providers.Find(id);

            if(provider != null) {
                _context.Providers.Remove(provider);
                _context.SaveChanges();
            }
        }
    }
}