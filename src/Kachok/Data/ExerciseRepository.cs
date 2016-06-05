using Kachok.Data.Infrastructure;
using Kachok.Data.Interfaces;
using Kachok.Model;
using System;
using System.Linq;

namespace Kachok.Data
{
    public class ExerciseRepository : RepositoryBase<Exercise, KachokContext>, IExerciseRepository
    {
        public ExerciseRepository(IDbFactory<KachokContext> dbFactory)
            : base(dbFactory)
        {
        }

        public Exercise GetExerciseByName(string exerciseName)
        {
            var category = this.DbContext.Exercises.Where(c => c.Name == exerciseName).FirstOrDefault();

            return category;
        }

        public override void Update(Exercise entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
