using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Product> _entities;

        public ProductRepository(AppDbContext context):base (context)
        {
            _context = context;
            _entities = _context.Set<Product>();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var data = await _entities
              .Where(x => !x.SoftDelete)
              .Include(entities => entities.Category)
              .ToListAsync();
            return data;
        }
    }
}
