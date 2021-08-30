using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext db;

        public PieRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return db.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return db.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetById(int id)
        {
            return db.Pies.Include(c => c.Category).SingleOrDefault(p => p.PieId == id);
        }
    }
}
