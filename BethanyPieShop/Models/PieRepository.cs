using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext context;

        public PieRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pie> AllPies => context.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfTheWeek => context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);

        public Pie GetPieById(int pieId)
        {
            return context.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
