using Kachok.Infrastructure;
using Kachok.Data.Interfaces;
using Kachok.Model;
using System;
using System.Linq;

namespace Kachok.Data
{
    public class ExerciseRepository : RepositoryBase<Exercise, KachokContext>, IExerciseRepository
    {
        public ExerciseRepository(KachokContext dbContext)
            : base(dbContext)
        {
        }

        public Exercise GetExerciseByName(string exerciseName)
        {
            var category = this.DbContext.Exercises.Where(c => c.Name == exerciseName).FirstOrDefault();

            return category;
        }

        public override void Update(Exercise entity)
        {
            base.Update(entity);
        }
    }
}
