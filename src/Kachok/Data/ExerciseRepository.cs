using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Data
{
    public class ExerciseRepository
    {
        private KachokContext _context;

        public ExerciseRepository(KachokContext context)
        {
            this._context = context;
        }
                
        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
