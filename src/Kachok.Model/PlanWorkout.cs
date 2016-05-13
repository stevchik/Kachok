using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Model
{
    public class PlanWorkout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PlanId { get; set; }
        public bool IsRestDay { get; set; }
        public List<PlanWorkoutExercise> PlanWorkoutExercises { get; set; }
    }
}
