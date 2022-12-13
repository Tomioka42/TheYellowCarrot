using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheYellowCarrot.Data;
using TheYellowCarrot.Models;

namespace TheYellowCarrot.Repositories
{
    public class TagRepo
    {
        private readonly AppDbContext _context;

        public TagRepo(AppDbContext context)
        {
            _context = context;
        }

        // Hämtar alla Tags

        public List<Tag> GetTags()
        {
            return _context.Tags.Include(t => t.Name).ToList();
        }
    }
}
