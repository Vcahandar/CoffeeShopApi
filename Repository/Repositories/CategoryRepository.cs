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
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Category> _entities;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Category>();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var result = await _entities
                .Where(m => m.SoftDelete == false)
                .Include(m => m.Products)
                .ToListAsync();

            return result;
        }
    }
}
