using Kachok.Infrastructure;
using Kachok.Model;

namespace Kachok.Data.Interfaces
{
    public interface IExerciseRepository: IRepository<Exercise>
    {
        Exercise GetExerciseByName(string exerciseName);
    }
}
